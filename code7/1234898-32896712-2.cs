     interface IPluginHost 
     {
          MyModelView ModelView {get;}
          MyMainWindow View {get;}
     }
 
     interface IPlugin
     {
        void Register(IPluginHost host);
        void Unregister();
     }
