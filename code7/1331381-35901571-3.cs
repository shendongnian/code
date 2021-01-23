    using System.Windows;
    using System.Windows.Threading;
    ...
    
    //this is needed because Application.Current will be NULL for a WinForms application, since this is a WPF construct so you need this ugly hack
    if (System.Windows.Application.Current  == null)
       new System.Windows.Application();
    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
    {
      //Do Your magic here 
    }), DispatcherPriority.Render);
