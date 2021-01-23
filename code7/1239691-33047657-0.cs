    public static class ThemeService {
        public static DependencyProperty IsPrepareModeProperty = 
                      DependencyProperty.RegisterAttached("IsPrepareMode", typeof(bool), typeof(ThemeService), 
                      new PropertyMetadata(isPrepareModeChanged));
        public static bool GetIsPrepareMode(UserControl e){
           return (bool) e.GetValue(IsPrepareModeProperty);
        }
        public static void SetIsPrepareMode(UserControl e, bool value){
           e.SetValue(IsPrepareModeProperty, value);
        }
        static isPrepareModeChanged(object sender, DependencyPropertyChangedEventArgs e){
           var u = sender as UserControl;
           u.LoadThemeResources((bool)e.NewValue);
        }        
    }
    //you need some public method of LoadThemeResources
    public void LoadThemeResources(bool isPrepareMode) {
         //...
    }
