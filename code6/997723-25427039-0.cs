    dateTimePicker1.CloseUp += (s, e) =>
       {
           Point p = Cursor.Position;
           if (todayRect.Contains(PointToClient(p)))
               Console.WriteLine("Today!");
       };
