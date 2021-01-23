    private static void OnIsEnabledChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
      {
         IconPresenter iconPresenter = (IconPresenter)sender;
         if ((bool)e.NewValue == false)
         {
            iconPresenter.Fill = Brushes.Transparent;
         }
         else
         {
            iconPresenter.Fill = Brushes.Black;          
         }
      }
