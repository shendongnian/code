        public UserControl1()
        {
            this.DefaultStyleKey = typeof(UserControl1);
        }
        public override void OnApplyTemplate()
        {
            base.ApplyTemplate();
            //Here, you can search for controls in template and store a reference to them 
            //for later use (same effect as defining controls directly in 
            //body of UserControl and attempting to use them in code behind). 
        }
