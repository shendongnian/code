     interface IPluginHost 
     {
          MyModelView ModelView {get;}
     }
 
     interface IPlugin
     {
        void Register(IPluginHost host);
        void Unregister();
     }
