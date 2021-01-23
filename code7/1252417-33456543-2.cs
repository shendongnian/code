    using System;
    using System.IO;
    using System.Text;
    using System.Diagnostics;
    
    namespace consoleencoding
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var tmpFile = Path.GetTempFileName ();
    			TextWriter tw = new StreamWriter(File.Open(tmpFile, FileMode.Create), Encoding.GetEncoding("iso-8859-1"));
    			tw.WriteLine("éèçàôûêâ");
    			tw.Close();
    			Process.Start ("vi", tmpFile);
    		}
    	}
    }
