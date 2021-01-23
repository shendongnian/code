    public partial class ProfileWindow : Window
    {
        private Dictionary<SettingsObject, UserControl> SettingsControls;
        public ProfileWindow()
        {
            SettingsControls = new Dictionary<SettingsObject, UserControl>();
            SettingsControls.Add(<your_setting>, new UserControl1());
            SettingsControls.Add(<your_another_setting>, new UserControl2());
            // and you can add any controls you want.
            // in this example SettingsObject is type of items that are in the ListView.
            // so, if your "Settings" object contains only strings, your dictionary can be Dictionary<string, UserControl>.
            // if SettingsObject is custom object, you have to override GetHash() and Equals() methods for it
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = SettingsList.SelectedItem is SettingsObject;
            if (item == null) return;
            if (SettingsControls.ContainsKey(item) && !dgRoot.Children.Contains(SettingsControls[item]))
            {
                dgRoot.Children.Clear();
                SettingsControls[item].SetValue(Grid.ColumnProperty, 2);
                dgRoot.Children.Add(SettingsControls[item]);
            }
            else
            { /*handle it if you want*/}
        }
    }
    }
