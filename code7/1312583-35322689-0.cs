    void ChangeTheme(Uri source)
        {   // Recreated my Merged dictinaries at the app.xaml
            var _Custom = new ResourceDictionary { Source = source };
            var _Main = new ResourceDictionary { MergedDictionaries = { _Custom } };
            App.Current.Resources = _Main;
            // This is needed to basiclly Refresh the page since we use Static Resources.
            // so we navigate forth and back to the whole frame.
    
            var _Frame = Window.Current.Content as Frame;
            _Frame.Navigate(_Frame.Content.GetType());
            _Frame.GoBack();
        }
