		private void frmMain_Load(object sender, EventArgs e)
		{
			CreateLang(); // Create new empty language
			//LoadLang(); // Load language, GUI must use {0} {1} ... as place-holder
		}
		private void LoadLang()
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile("eng.ini");
			Control ctrl = this;
			do
			{
				ctrl = this.GetNextControl(ctrl, true);
				if (ctrl != null)
					if (ctrl is Label ||
						ctrl is Button ||
						ctrl is TabPage ||
						ctrl is CheckBox)
						if (data["Root"][ctrl.Name].Contains('|')) // Character | donated by New-Line, \n
							ctrl.Text = String.Format(ctrl.Text, data["Root"][ctrl.Name].Split('|'));
						else
							ctrl.Text = String.Format(ctrl.Text, data["Root"][ctrl.Name]);
			} while (ctrl != null);
		}
		private void CreateLang()
		{
			if (System.IO.File.Exists("eng.ini"))
				System.IO.File.WriteAllText("eng.ini", "");
			else
				System.IO.File.WriteAllText("eng.ini", "");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile("eng.ini");
			data.Sections.AddSection("Info");
			data.Sections["Info"].AddKey("Name", "Anime4000");
			data.Sections["Info"].AddKey("Version", "0.1");
			data.Sections["Info"].AddKey("Contact", "fb.com/anime4000");
			string main = "Root";
			data.Sections.AddSection(main);
			Control ctrl = this;
			do
			{
				ctrl = this.GetNextControl(ctrl, true);
				if (ctrl != null)
					if (ctrl is Label ||
						ctrl is Button ||
						ctrl is TabPage ||
						ctrl is CheckBox ||
						ctrl is GroupBox)
						data.Sections[main].AddKey(ctrl.Name, "");
			} while (ctrl != null);
			parser.WriteFile("eng.ini", data);
		}
