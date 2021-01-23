     public partial class MyFirstPlugin : UserControl, IPlugin
     {
          ...
         void Register(IPluginHost host)
         {
              _host = host;
               // Attach main model view as data context
               this.DataContext = host.ModelView; 
               // Add control to the host's container
               var mainWindow = host.View;
               mainWindow.AddPluginControl((UserControl)this);
         }
         void Unregister()
         {
              if (_host == null)
              { 
                  return;
              }
              this.DataContext = null;
              _host.View.RemovePluginControl(this);
              _host = null;
         }
         IPluginHost _host;
     }
