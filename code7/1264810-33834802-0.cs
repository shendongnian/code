    public void MethCaller(string FileName,foo_dele delfoo , bar_dele delbar)
    {
         //File operations to fetch parameters from file.
    
         if(some_parameter)
         {
             delefoo = foo;
         }
         else
         {
             delebar = bar;
         }
    
         //call the dele if its got a reference to a method in it.
         if(!(delefoo.Target || delfoo.Method))
         {
            delfoo(pram1,param2);
            return;
         }
         delbar(param3,param4);
         return;
    }
