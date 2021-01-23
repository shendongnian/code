    var numberGroupsTimes5 =
                from n in numbers
                group n by n % 5 into g
                select new { Remainder = g.Key, Numbers = g };
    var numberGroupsTimes4 =
                from n in numbers
                group n by n % 4 into g
                select new { Remainder = g.Key, Numbers = g };
    foreach (var g in numberGroupsTimes5)
    {
      if (g.Remainder == 0)
      {
         string st = string.Format("Numbers with a remainder of {0} when divided by 5:" , g.Remainder);
         MessageBox.Show("" + st);
         foreach (var n in g.Numbers)
         {
              MessageBox.Show(""+n);
         }
      }
    } 
    foreach (var g in numberGroupsTimes4)
    {
          if (g.Remainder == 0)
          {
               string st = string.Format("Numbers with a remainder of {0} when divided by 4:", g.Remainder);
               MessageBox.Show("" + st);
               foreach (var n in g.Numbers)
               {
                   MessageBox.Show("" + n);
               }
          }
    } 
