        struct Cities
        {
            public string name;
            public int n;
        }
 
        [Test]
        public void SomeMethod()
        {
            Cities[] c = new Cities[7];
            c[0].name = "new york";
            c[0].n = 10;
            c[1].name = "detroit";
            c[1].n = 20;
            c[2].name = "las vegas";
            c[2].n = 30;
            c[3].name = "new york";
            c[3].n = 40;
            c[4].name = "detroit";
            c[4].n = 50;
            c[5].name = "chicago";
            c[5].n = 60;
            c[6].name = "chicago";
            c[6].n = 70;
            c = c.GroupBy(ct => ct.name)
                .Select(cl => new Cities
                {
                    name = cl.First().name,
                    n = cl.Sum(ct => ct.n)
                }).ToArray();
            foreach (var city in c)
            {
                Console.WriteLine($"city={city.name}, pop={city.n}");
            }
        }
