         public async Task<ActionResult> SomeAction()
        {
            return View("ViewName", await Task.Run(() => { ImportTask(); }));
        }
        public async Task ImportTask()
        {
            using (var context = new ApplicationDBContext()) 
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                for (var i = 0; i < 180; i++)
                {
                    var data = GetSomeDataFromAnotherServer(i);
                    foreach (var dataPart in data)
                    {
                        var stat = context.Data.FirstOrDefault(x => x.EnumProperty == dataPart.EnumProperty && x.LongProperty == dataPart.LongProperty && x.DateTimeProperty == dataPart.DateTimeProperty) 
                            ?? new DataType()
                                                                                                                                                                                                                  {
                        ...
                        (some
                        another stat 
                        filling)
                        context.Statistics.AddOrUpdate(stat);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
