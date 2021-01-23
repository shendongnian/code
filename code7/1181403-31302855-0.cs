    class Owner : Form
    {
       private Child Child;
       public Owner()
       {
           Child = new Child("Value To Pass");
       }
    }
    class Child : Form
    {
        
        public Child(string value)
        {
            //do something with value
        }
    }
