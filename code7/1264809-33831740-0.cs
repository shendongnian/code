    public void MethodCaller(string FileName)
    {
         //File operations to fetch parameters from file.
         Route(some_parameter,
               other_parameter1, other_parameter2,
               other_parameter3, other_parameter4);
    }
    
    public void Route(string some_parameter, parms object[] parameters)
    {
         if(some_parameter)
         {
             foo(parameters[0],parameters[1]);
         }
         else
         {
             bar(parameters[2],parameters[3]);
         }
    }
