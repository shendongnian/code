            var data = collection.Aggregate();
            var a1 =
                data.Project(
                    x =>
                        new 
                        {
                            FSTicker = x.FSTicker,
                            Sedol = x.Sedol,
                            Company = x.Company,
                            Exchange = x.Exchange,
                            LocalTicker = x.LocalTicker,
                            IsTrue = (x.Sedol == x.FSTicker)
                        });
            var a2 = a1.Match(x => x.IsTrue);
            var result = a2.ToList();
