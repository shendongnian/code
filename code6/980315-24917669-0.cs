    DayOfWeek[] Days = new DayOfWeek[7];
    DayOfWeek[0] = DateTime.Now.DayOfWeek;
    For(Int i=1;i < 7;i++)
      DayOfWeek[i] = (DayOfWeek)(((byte)DayOfWeek[i-1]+1) % 7);
    XElement[] XmlDays = new XElement[7];
    For(Int i=0;i < 7;i++)
      XmlDays[i] = new XElement("day" + i.ToString(), DayOfWeek[i]);
    xFore.Root.Add(XmlDays);
