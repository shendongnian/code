        public class Shell : IShell
        {
            public event ModuleShownEventHandler ModuleShown;
            public void OnModuleShown()
            {
                ModuleShownEventHandler handler = ModuleShown;
                if (handler != null)
                {
                    handler(this, new ModuleShownEventArgs());
                }
            }
        }
