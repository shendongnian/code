    public abstract class Base {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
    
  	    public void Method(string variable) {
            Console.WriteLine(this.Prop1);
            Console.WriteLine(this.Prop2);
            Console.WriteLine(this.Prop3);
        }
    }
    
    public class Class1 : Base {
        public Class1() {
            Prop1 = "Class 1 Property 1";
            Prop2 = "Class 1 Property 2";
            Prop2 = "Class 1 Property 3";
        }
    }
    
    public class Class2 : Base {
        public Class2() {
            Prop1 = "Class 2 Property 1";
            Prop2 = "Class 2 Property 2";
            Prop2 = "Class 2 Property 3";
        }
    }
    
    public class Class3 : Base {
        public Class3() {
            Prop1 = "Class 3 Property 1";
            Prop2 = "Class 3 Property 2";
            Prop2 = "Class 3 Property 3";
        }
    } 
