        public void Run()
        {
            List<string> classList = new List<string>
            {
                "EventOne",
                "EventTwo"
            };
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            foreach (string item in classList)
            {
                IEvent ent = Activator.CreateInstance(Type.GetType(assemblyName + "." + item)) as IEvent;
                if (ent != null)
                  ent.HandlEvent();
            }
        }
