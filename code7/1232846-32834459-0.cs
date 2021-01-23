    public class A 
    {
       public string Question {get;set;}
    }
    public class B : A 
    { 
        public string Answer {get;set;}
    }
    T Echo<T>(T arg) where T : A 
    {
       Console.WriteLine(arg.Question); // we know arg is at least "A"
       return arg;
    }
    var a = new A {Question = "Q1"};
    var b = new B {Question = "Q2"};
    Echo(a); // result is of type A
    Echo(b).Answer = "42"; // result is of type B - can use "Asnwer"
    Echo(3); // Compile error 3 is not A.
  
