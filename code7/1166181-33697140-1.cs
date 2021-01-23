    AppDomain.CurrentDomain.UnhandledException += UEHandler;
    //...
    static void UEHandler(object sender, UnhandledExceptionEventArgs e){
      if( e.ToString().Contains( "DBRBackupOverlayIcon" ){
        //show some dialog here telling users to uninstall DBaR
      }
    }
