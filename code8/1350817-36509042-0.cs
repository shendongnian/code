        //This list is used to properly dispose PrivateFontCollection after usage
  		static private List<PrivateFontCollection> _fontCollections;
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);	//Mandatory in order to have Memory fonts rendered in the controls.
			
            //Dispose all used PrivateFontCollections when exiting
			Application.ApplicationExit += delegate {
				if (_fontCollections != null) {
					foreach (var fc in _fontCollections) if (fc != null) fc.Dispose();
					_fontCollections = null;
				}
			};
            Application.Run(new frmMain());
		}
		
		void frmMain_Load(object sender, EventArgs e)
		{
			Font font1 = GetCustomFont(Properties.Resources.Amatic_Bold, 25, FontStyle.Bold);
			//or...
			Font font1 = GetCustomFont("Amatic-Bold.ttf", 25, FontStyle.Bold);
			
			labelTestFont1.Font = font1;
			Font font2 = GetCustomFont(Properties.Resources.<font_resource>, 25, FontStyle.Bold);
			//or...
			Font font2 = GetCustomFont("<font_filename>", 25, FontStyle.Bold);
			
			labelTestFont2.Font = font2;
			
			//...
		}
		static public Font GetCustomFont (byte[] fontData, float size, FontStyle style)
	    {
			if (_fontCollections == null) _fontCollections = new List<PrivateFontCollection>();
			PrivateFontCollection fontCol = new PrivateFontCollection();
			IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
			Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
			fontCol.AddMemoryFont(fontPtr, fontData.Length);
			Marshal.FreeCoTaskMem(fontPtr);		//<-- It works!
			_fontCollections.Add (fontCol);
			return new Font(fontCol.Families[0], size, style);
	    }
		
		
		static public Font GetCustomFont (string fontFile, float size, FontStyle style)
	    {
			if (_fontCollections == null) _fontCollections = new List<PrivateFontCollection>();
			PrivateFontCollection fontCol = new PrivateFontCollection();
			fontCol.AddFontFile (fontFile);
			_fontCollections.Add (fontCol);
			return new Font(fontCol.Families[0], size, style);
	    }
