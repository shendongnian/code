    using System.Windows;
    using System.Windows.Threading;
    ...
    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
    {
      //Do Your magic here 
    }), DispatcherPriority.Render);
