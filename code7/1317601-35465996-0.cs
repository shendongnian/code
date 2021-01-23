    class Program
    {
        static void Main()
        {
            var rj = new RunningJob();
            rj.Property = new Child1();
            rj.Property = new Child2();
        }
    }
    public class RunningJob { 
        public Parent Property { get; set; }
    }
    public class Parent {    }
    public class Child1 : Parent {    }
    public class Child2 : Parent {    }
