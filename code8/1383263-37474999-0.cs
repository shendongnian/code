    string myStr = "= '2015-12-01 00:00:00.000'";
     DateTime dt;
     bool b = DateTime.TryParse(myStr.Split(' ')[1].Replace("'",string.Empty),out dt);
         if (b)
         {
              Console.WriteLine("contains datetime");
         }
         else
         {
              Console.WriteLine("doesn't contain datetime");
         }
