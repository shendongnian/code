    public class MyClassB
    {
        private MyClassA myVar;
        public MyClassA InstanceOfA
        {
            get { return myVar; }
            private set
            {
                myVar = value;
                if (myVar != null)
                    myVar.PropertyChanged += MyEventHandler;
            }
        }
        public void MyEventHandler(object sender, EventArgs e)
        {
        
        }
    }
