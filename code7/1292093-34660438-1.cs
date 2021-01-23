        public void ThemeImagePath(object sender, RoutedEventArgs e)
        {
            var Image = (Image)sender;
            var Theme = Image.DataContext as IPerformTheme;
            Image.Source = ImageHelper.BitmapSourceFromPath(new Uri(Model.ApplicationRoots.ThemeRoot + "/TemplateThemes/" + Theme.Name + "/thumbnail.png")); 
        }
