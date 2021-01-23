    Select(x =>
                {
                    var obj = new TestData
                    {
                        Lastname = x.Lastname,
                        Firstname = x.Firstname
                    };
                    if (!string.IsNullOrEmpty(x.Middlename))
                        obj.Middlename = x.Middlename;
                    return obj;
                });
