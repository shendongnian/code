    public MyControl : UserControl
    {
         public new string Name 
         {
             get  { return base.Name; }
             set  
             {
                base.Name = value;
                // handle the name change here....
             }
        }
    }
