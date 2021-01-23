    int CountFileToCheck;
    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render,
      new Action(() => {                                   
       CountFileToCheck=Directory.GetFiles(textBox_UpdatedBuildPath.Text, "*", SearchOption.AllDirectories).Length;}));
    });
