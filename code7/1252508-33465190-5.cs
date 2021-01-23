    using System;
    using System.Reflection;
    using System.IO;
    using Gtk;
    
    namespace themes
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			InitGlobalResourceFile ();
    			Application.Init ();
    			MainWindow win = new MainWindow ();
    			win.Show ();
    			Application.Run ();
    		}
    
    		static void InitGlobalResourceFile ()
    		{ 
    			String gtkResouceFile;
    
    			Assembly myAssembly = Assembly.GetExecutingAssembly ();
    			string[] names = myAssembly.GetManifestResourceNames ();
    			foreach (string name in names) {
    				Console.WriteLine (name);
    				if (name.Contains ("GtkThemeResource.rc")) {
    					gtkResouceFile = name;
    					break;
    				}
    				Console.WriteLine ("Gtk Theme Resource not found in manifest");
    			}
    
    			var tmpFile = Path.GetTempFileName ();
    			var stream = myAssembly.GetManifestResourceStream (gtkResouceFile);
    			string gtkrc;
    			using (StreamReader reader = new StreamReader (stream)) {
    				gtkrc = reader.ReadToEnd ();
    			}
    			using (StreamWriter outputFile = new StreamWriter (tmpFile)) {
    				outputFile.WriteLine (gtkrc);
    			}
    			Rc.AddDefaultFile (tmpFile); 
    			Rc.Parse (tmpFile); 
    		}
    
    	}
    }
