    case "BTEXIT":
          string strError;
          this.btShow.Content = "Serializing";
          this.btExit.Content = "Please wait";
          Dispatcher.Invoke((Action)(() => { }), DispatcherPriority.Render);
          this.UpdateLayout();
          Serializers.Logger.WriteLog_Reflection<PCDmisLogEntry>;
          System.Threading.Thread.Sleep(2000);
          Environment.Exit(0);
          break;
