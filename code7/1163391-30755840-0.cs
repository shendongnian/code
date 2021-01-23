     var d = new DateTime();
      d = d.Date.AddHours("0").AddMinutes("0");
      for (int i = 0; i < 48; i++)
      {
            d.AddMinutes(30);
            cbo.AddItem(d.TimeOfDay.ToString());
      }
