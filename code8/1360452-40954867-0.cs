    CSapROTWrapper sapROTWrapper = new CSapROTWrapper();
            object rot = sapROTWrapper.GetROTEntry("SAPGUI");
            object engine = rot.GetType().InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, rot, null);
            GuiConnection connection = (engine as GuiApplication).OpenConnection(connectionName);
            GuiSession session = connection.Children.ElementAt(0) as GuiSession;
