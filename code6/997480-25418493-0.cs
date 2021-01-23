     public class Person
        {
            [XmlIgnore]
            public int Id { get; set; }
            [XmlIgnore]
            public string Name { get; set; }
            public double Salary { get; set; }
    
            public Person()
            {
                Id = 1;
                Name = "Sam";
                Salary = 50000.00;
            }
        }
