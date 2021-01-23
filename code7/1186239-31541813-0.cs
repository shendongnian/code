        protected override ControlCollection CreateControlsInstance()
        {
            ObservableControlCollection controls = new ObservableControlCollection(this);
            controls.ControlAdded += new Action<Control>(controls_ControlAdded);
            return controls;
        }
        void controls_ControlAdded(Control addedControl)
        {
            Debug.WriteLine("Control added:" + addedControl.Name);
        }
        private sealed class ObservableControlCollection : ControlCollection
        {
            public event Action<Control> ControlAdded;
            
            public ObservableControlCollection(Control owner)
                : base(owner)
            {
            }
            public override void Add(Control control)
            {
                base.Add(control);
                Action<Control> handler = ControlAdded;
                if (handler != null)
                {
                    handler(control);
                }
            }
            // Similarly for removing controls:
            public override void Remove(Control value) { ... }
            public override void Clear() { ... }
        }
