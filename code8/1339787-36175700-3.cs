    List<ComboControl> _comboControls = new List<ComboControl>();
    
            public ContainerControl()
            {
                InitializeComponent();
            }
    
            private void ContainerControl_Load(object sender, EventArgs e)
            {
                _comboControls.Add(new ComboControl());
                _comboControls.Add(new ComboControl());
                _comboControls.Add(new ComboControl());
    
                foreach (ComboControl value in _comboControls)
                {
                    flowLayoutPanel.Controls.Add(value);
                    //Subscribe to Custom Event here
                    value.DeleteControlDelegate += Value_DeleteControlDelegate;
                }
            }
    
            private void Value_DeleteControlDelegate(object sender)
            {
                //When Raised Delete ComboControl
                flowLayoutPanel.Controls.Remove((Control) sender);
            }
        }
