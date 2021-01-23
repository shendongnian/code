    class Owner : Form
    {
       public Owner()
       {
           Child = new Child();
           Child.ShowDialog();
           string childValue = Child.Value;
       }
    }
    class Child : Form
    {
        public string Value{get;set;}
        public Child()
        {
            
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            value = "Value To Set";
            this.Close();
        }
    }
