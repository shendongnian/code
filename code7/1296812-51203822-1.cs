     mockSet.Setup(x => x.Add(It.IsAny<ValuationCompany>()))
                    .Callback<ValuationCompany>(data.Add)
                    .Returns<ValuationCompany>(p =>
                    {
                        p.Id = 23;  // Assign whatever you want here.
                        return p;
                    });
