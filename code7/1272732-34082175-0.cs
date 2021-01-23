    var result = dc.ExampleEntity1.Include(ee =>ee.TextEntry.LocalizedContents)
                   .Select(x=>new
                   {
                      //Try anonymous or a projection to your model.
                      //As this Select is IQuerable Extension it will execute in the data store and only retrieve filtered data.
                      exampleEntity = x,
                      localizedContetnt = x.TextEntry.LocalizedContents.Where(g=>g.Id==YourKey),
                   }).FirstOrDefault();   
