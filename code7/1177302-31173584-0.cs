     StreamReader sr = new StreamReader(stream);
     StringBuilder S = new StringBuilder();
     while(true)
     {
     S = S.Append(sr.ReadLine());
     if (sr.EndOfStream  == true)
          {
             break;
          }
     }
