        public Form1()
        {
            InitializeComponent();
            this.button1.Click += Button1_Click;
            this.button1.Click += Button1_Click1;
            PropertyInfo propertyInfo = button1.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            EventHandlerList eventHandlerList = propertyInfo.GetValue(button1, new object[] { }) as EventHandlerList;
            FieldInfo fieldInfo = typeof(Control).GetField("EventClick", BindingFlags.NonPublic | BindingFlags.Static);
            var eventKey = fieldInfo.GetValue(button1);
            var eventHandler = eventHandlerList[eventKey] as Delegate;
            Delegate[] invocationList = eventHandler.GetInvocationList();
            var names = new List<string>();
            foreach (var handler in invocationList)
            {
                names.Add(handler.GetMethodInfo().Name);
            }
        }
