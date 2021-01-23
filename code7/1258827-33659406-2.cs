    var document = XDocument.Load(path);
    var elements = (from column in document.Descendants("column")
                   select new
                   {
                        AttributeName = column.Attribute("name").Value,
                        Parent = column,
                        Run = column.Descendants("run").FirstOrDefault()
                   }).ToList();
    foreach(var item in elements)
    {
         XElement run;
         if (item.Run == null)
         {
              run = new XElement("run");
              item.Parent.Add(
                  new XElement("desc", 
                      new XElement("formatted-text", 
                          run
                      )
                  )
              );
          }
          else
          {
               run = item.Run;
          }
          if(item.AttributeName == "BlaBlaOne")
          {
               run.Value = "Your definition here";
          }
     }
     document.Save(path);
