    // Sample data
    var collection = new List<A>
    {
        new A()
        {
            B = new List<B>
            {
                new B { system_date_time = DateTime.Now.AddHours(-1) },
                new B { system_date_time = DateTime.Now.AddHours(-2) },
                new B { system_date_time = DateTime.Now.AddHours(-3) },
            }
        },
        new A()
        {
            B = new List<B>
            {
                new B { system_date_time = DateTime.Now.AddHours(-1) },
                new B { system_date_time = DateTime.Now.AddHours(-2) },
                new B { system_date_time = DateTime.Now.AddHours(-3) },
            }
        },
        new A()
        {
            B = new List<B>
            {
                new B { system_date_time = DateTime.Now.AddHours(-1) },
                new B { system_date_time = DateTime.Now.AddHours(-2) },
                new B { system_date_time = DateTime.Now.AddHours(-3) },
            }
        }
    };
    var sorted = collection.OrderByDescending(x => x.B.Max(y => y.system_date_time));
