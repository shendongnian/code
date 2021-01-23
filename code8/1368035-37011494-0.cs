     class A
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
    
            public string Property100 { get; set; }
    
            public string Property200 { get; set; }
        }
    
        class B : A
        {
            public string PropertyB_1 { get; set; }
            public string PropertyB_2 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<A> list = new List<A>();
                for (int i = 0; i < 10; i++)
                {
                    A a = new B()
                    {
                        Property1 = "P1_" + i,
                        Property2 = "P2_" + i,
                        Property100 = "P100_" + i,
                        Property200 = "P200_" + i,
                        PropertyB_1 = "PB_1_" + i,
                        PropertyB_2 = "PB_2_" + i
                    };
                    list.Add(a);
                }
                //list only contains A data
                foreach (A a in list)
                {
                    //save a to database
                }
            }
        }
