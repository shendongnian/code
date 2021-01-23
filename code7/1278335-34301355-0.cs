            foreach (UIElement child in stackpanel.Children)
            {
                if (child is ProgressRing)
                {
                    var ring = (ProgressRing)child;
                    if (await image_folder.TryGetItemAsync("image_" + ring.Name + ".jpg") != null)
                    {
                       var tmp = new Image();
                        tmp.Margin = new Thickness(0, 0, 0, 50);
                        tmp.Margin = new Thickness(0, 50, 0, 50);
                        tmp.Name = ring.Name;
                        tmp.DoubleTapped += Tmp_DoubleTapped;
                        tmp.Source = new BitmapImage(new Uri("ms-appdata:///local/images/image_" + ring.Name + ".jpg", UriKind.Absolute));
                        var location = stackpanel.Children.IndexOf(child);
                        if (location < 0)
                        {
                        return;
                        }
                        Debug.WriteLine("Replacing " + location);
                        stackpanel.Children.Remove(child);
                        stackpanel.Children.Insert(location, tmp);
                        Debug.WriteLine("Done replacing");
                    }
                }
            }
