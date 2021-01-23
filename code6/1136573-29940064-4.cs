    var txt = "Name of House: Aasleagh Lodge\r\nTownland: Srahatloe\r\nNear: Killary Harbour, Leenane\r\nStatus/Public Access: maintained, private fishing lodge\r\nDate Built: 1838-1850, burnt 1923, rebuilt 1928\r\nName of House: House of Lan\r\nTownland: Another town land\r\nNear: Killary Harbour, Leenane\r\nStatus/Public Access: maintained, private fishing lodge\r\nDate Built: 1838-1850, burnt 1923, rebuilt 1928\r\nName of House: New Lodge\r\nTownland: NewTownLand\r\nNear: Killary Harbour, Leenane\r\nStatus/Public Access: maintained, private fishing lodge\r\nDate Built: 1838-1850, burnt 1923, rebuilt 1928";
    using (var sr = new StringReader(txt))
    {
       var s = string.Empty;
       var nameOfHouse = new StringBuilder();
       var townland = new StringBuilder();
       while ((s = sr.ReadLine()) != null)
       {
          if (s.StartsWith("Name of House"))
          {
              nameOfHouse.Append(s.Split(new[] {':'})[1].Trim());
          }
          else if (s.StartsWith("Townland"))
          {
               townland.Append(s.Split(new[] { ':' })[1].Trim());
          }
          if (nameOfHouse.Length > 0 && townland.Length > 0)
          { 
              // INSERT THE VALUES AND RESET THEM
              nameOfHouse.Clear(); townland.Clear();
          }
       }
    }
