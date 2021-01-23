    List<string> numbers= new List<string>();
    string curNumber="";
    foreach( char c in test)
    {
       if (c =='+'|| c =='-'||c =='/'||c =='*')
       {
         numbers.Add(curNumber);
         curNumber="";
       }
       else
       {
         //also you can add operators in other list here
         curNumber+=c.ToString();
       }
    }
    numbers.Add(curNumber);
