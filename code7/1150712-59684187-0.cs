    public class A()
    {
       public virtual string aaa{get;set;}
       public virtual string bbb{get;set;} //bbb is defined in the BBB already!!!
       public virtual BBB bigB{get;set;}
    }
    
    public class BBB(){
       public virtual string bbb{get;set;}
    }
