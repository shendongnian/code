    public void ParentFunction()
    {
       try
       {
          foreach (var item in someArray)
          {
             if( ! child_function1())
                continue;
             if( ! child_function1())
                continue;
             child_function3();
          }
       }
       catch(Exception exc)
       {
          console.Writeline(exc.Message);
       }
    }
