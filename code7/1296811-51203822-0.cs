     mockSet.Setup(x => x.Add(It.IsAny<ValuationCompany>()))
                    .Callback<ValuationCompany>(data.Add)
                    .Returns<ValuationCompany>(p =>
                    {
                        p.Id = 23;  // assing whatever you want here.
                        return p;
                    });
