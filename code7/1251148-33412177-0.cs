    private string FunctionWithTwoParameters(string name="", int count=0)
    {
       if (count > 0)
       {
          for (int i = 0; i < count; i++)
          {
             name += name;                    
          }                
       }
       return name;
    }
