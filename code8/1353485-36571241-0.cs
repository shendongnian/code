    static void Main(string[] args)
            {
                Position p = new Position();
                p.positionName = "Manager";
                p.salary = 1000;
    
                Employee e = new Employee();
                e.name = "John";
                e.position = p;
    
                ResultJson r = new ResultJson();
                r.name = e.name;
                r.positionName = e.position.positionName;
                r.salary = e.position.salary;
    
                var result = JsonConvert.SerializeObject(r);
    
                Console.WriteLine(result);
                Console.ReadLine();
            }
    
        }
    
        public class Employee
        {
            public string name { get; set; }
            public Position position { get; set; }
        }
    
        public class Position
        {
            public string positionName { get; set; }
            public int salary { get; set; }
        }
    
        public class ResultJson
        {
            public string name { get; set; }
            public string positionName { get; set; }
            public int salary { get; set; }
        }
