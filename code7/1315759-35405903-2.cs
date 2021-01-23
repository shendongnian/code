    class MyControl : Control
    {      
        private Color foreColor = SystemColors.ControlText;
        public override Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }
    }
