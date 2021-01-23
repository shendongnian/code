    TabItem ti = null;
    Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
     {
       ti = new TabItem();
       ti.Header = saha.SahaAdı + " (" + saha.SahaTipi + ")";
       ti.Content = ug;
      });
