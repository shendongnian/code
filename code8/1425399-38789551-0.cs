    char[] soFlow = new char[100];
    int posn = 0;
    using (StreamReader sr = new StreamReader("a.txt"))
       using (StreamWriter sw = new StreamWriter("b.txt", false))
          while(sr.EndOfStream == false)
          {
              try {
                 int i = sr.Read(soFlow, posn%100, 100);
                 posn += 100;
                 sw.WriteLine(new string(soFlow));
              }
              catch(Exception e){Console.WriteLine(e.Message);}
          } 
