    class MyClass
    {
        [Category("Common")]
        [Description("Name")]
        [Browsable(true)]
        public string Name
        {
            get { return name;} 
            set { name = value; }
        }
        [Category("Common")]
        [Description("Contact")]
        [Browsable(true)]
        public string ContactNo
        {
            get { return number;} 
            set { number = value; }
        }
        public bool ContactNoVisible
        {
            //Change the condition
            get {return Name != "bttb"; }
        }
    }
