		private void Form1_Load( object sender, EventArgs e ) {
			MemoryFonts.AddMemoryFont( Properties.Resources.fontawesome_webfont );
			textBox1.Font = MemoryFonts.GetFont(
								// using 0 since this is the first font in the collection
								0,
								// this is the size of the font
								20, 
								// the font style if any. Bold / Italic / etc
								FontStyle.Regular
							);
			// since I am using FontAwesome, I would like to display one of the icons
			// the icon I chose is the Automobile (fa-automobile). Looking up the unicode
			// value using the cheat sheet https://fortawesome.github.io/Font-Awesome/cheatsheet/
			// shows :  fa-automobile (alias) [&#xf1b9;]
			// so I pass 'f1b9' to my UnicodeToChar method which returns the Automobile icon 
			textBox1.Text = MemoryFonts.UnicodeToChar( "f1b9" );
		}
