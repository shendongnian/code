    var document = XDocument.Load(path);
    var elements = (from column in document.Descendants("column")
                   select new
                   {
                       AttributeName = column.Attribute("name").Value,
                       Run = column.Descendants("run").FirstOrDefault()
                   }).ToList();
     foreach(var item in elements)
     {
          if (item.Run == null) continue;
          if(item.AttributeName == "BlaBlaOne")
          {
              item.Run.Value = "Your definition here";
          }
     }
     document.Save(path);
