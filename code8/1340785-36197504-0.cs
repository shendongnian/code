    public class Class02
        {
            public Data Integer { get; set; }
        }
        public class Class01
        {
            public Data Integer { get; set; }
        }
        public class Data {
    
            public int Integer { get; set; }
        }
        public class A
        {
            private void myFunc()
            {
                Data data = new Data();
                data.Integer = 16;
                Class01 one = new Class01 { Integer = data };
                Class02 two = new Class02 { Integer = data };
                Console.WriteLine("Class one: {0} -- Class two: {1}", one.Integer.Integer, two.Integer.Integer);
                // Prints: Class one: 16 -- Class two: 16
                data.Integer++;
                Console.WriteLine("Class one: {0} -- Class two: {1}", one.Integer.Integer, two.Integer.Integer);
                // Prints:             Class one: 17 -- Class two: 16
                // I want it to print: Class one: 17 -- Class two: 17
            }
        }
