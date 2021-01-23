    foreach(var item in Directory.GetFiles(@\Desktop").Where( shortcut => shortcut.EndsWith(".lnk")))
            {
                var icon = Icon.ExtractAssociatedIcon(item);
                ShortcutItems.Add(new Shortcut() { Name = System.IO.Path.GetFileName(item.Substring(0, item.Length - 4)),,
                BitMapIcom = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icc.Handle,
                             System.Windows.Int32Rect.Empty,
                             System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions())});      
            }
