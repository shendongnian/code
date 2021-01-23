    Properties.Settings.Default.Reload();
	Properties.Settings.Default.MainScreenLeft = this.Left;
	Properties.Settings.Default.MainScreenTop = this.Top;
	Properties.Settings.Default.MainScreenWidth = this.Width;
	Properties.Settings.Default.Save();
	Properties.Settings.Default.Mode = CboMode.SelectedItem.ToString();
