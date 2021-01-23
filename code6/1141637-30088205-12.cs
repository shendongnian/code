    private ObservableCollection<Shortcut> shortcutItems;
        public ObservableCollection<Shortcut> ShortcutItems
        {
            get { return shortcutItems; }
            set { shortcutItems = value; }
        }
      
    private ObservableCollection<Shortcut> GetIcons()
        {
            if (shortcutItems == null)
                shortcutItems = new ObservableCollection<Shortcut>();
            shortcutItems.Clear();
            foreach (var item in Directory.GetFiles(@"C:\Users\albErt\Desktop").Where(x => x.EndsWith(".lnk")))
            {
                var icc = Icon.ExtractAssociatedIcon(item);
                shortcutItems.Add(new Shortcut()
                {
                    Name = System.IO.Path.GetFileName(item.Substring(0, item.Length - 4)),
                    BitMapIcom = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icc.Handle,
                                 System.Windows.Int32Rect.Empty,
                                 System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions())
                });
            }
            return shortcutItems;
        }
