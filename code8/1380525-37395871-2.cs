    foreach (DataRow datarow in sorted.Rows)
    {
         Boolean first = true;
         Console.Write(Environment.NewLine);
         foreach (var item in datarow.ItemArray)
         {
              if (!string.IsNullOrEmpty((item ?? "").ToString()))
              {
                   int i = 0;
                   if (first)
                       first = false;
                   else
                        Console.Write(",");
                       Console.Write(item);
                    }
                    else
                        continue;
          }
    }
