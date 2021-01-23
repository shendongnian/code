    public void ParentFunction()
    {
       try
       {
          foreach (var item in someArray)
          {
             try 
	         {
			    procedure1();
				procedure2();
				procedure3();
			 }
			 catch(Exception exc)
		     {
			    continue;
			 }
             
          }
       }
       catch(Exception exc)
       {
          console.Writeline(exc.Message);
       }
    }
