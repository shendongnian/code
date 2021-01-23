    public class Parent
    {
        public class child1 { public string name = "a"; public int Value = 1;}
        public class child2 { public string name = "b"; public int Value = 2;}
        public class child3 { public string name = "c"; public int Value = 3;}
        public class child4 { public string name = "d"; public int Value = 4;}
        public class child5 { public string name = "e"; public int Value = 5;}
        public child1 c1;
        public child2 c2;
        public child3 c3;
        public child4 c4;
        public child5 c5;
        public Parent() {
            this.c1 = new child1();
            this.c2 = new child2();
            this.c3 = new child3();
            this.c4 = new child4();
            this.c5 = new child5();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Parent p1 = new Parent();
            Console.WriteLine(p1.c1.name);
            Console.WriteLine(p1.c2.name);
            Console.WriteLine(p1.c3.name);
            Console.WriteLine(p1.c4.name);
            Console.WriteLine(p1.c5.name);
            Console.ReadLine();
        }
