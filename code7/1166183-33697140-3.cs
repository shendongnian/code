    AppDomain.CurrentDomain.UnhandledException += UEHandler;
    //...
    static void UEHandler(object sender, UnhandledExceptionEventArgs e){
      var ex = e.ExceptionObject as Exception;
      if( ex.ToString().Contains( "DBRBackupOverlayIcon" ){
        //show some dialog here telling users to uninstall DBaR
      }
    }
