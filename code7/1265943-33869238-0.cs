    public class Common
    {
        public string field1 { get; set; };
        public string field2 { get; set; };
        public string field3 { get; set; };
        public string field4 { get; set; };
        public string field5 { get; set; };
        public string field6 { get; set; };
        public string field7 { get; set; };
        public string field8 { get; set; };
    }
    public class A : Common
    {
        public string anotherA1 { get; set; };
        public string anotherA2 { get; set; };
    }
    public class B : Common
    {
        public string anotherB1 { get; set; };
        public string anotherB2 { get; set; };
    }
    
    A a = new A();
    B b = new B();
    Common d;
    
    if(isDo)
       d= a;
    else
       d= b;
    
    string strField = d.field1;
    string test = d.field3;
