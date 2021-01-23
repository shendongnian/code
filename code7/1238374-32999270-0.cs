    public abstract Class MyBaseClass
    {
       protected virtual string var1 { get { return ""; } }
       protected virtual string var2 { get { return ""; } }
       protected virtual string var3 { get { return ""; } }
       public bool myfunc()
       {
           //code to do something with var1...var3
       }
    }
     public class myderivedclass: MyBaseClass
     {
         protected override string var1 { get { return "whatever"; } }
         protected override string var2 { get { return "something"; } }
         protected override string var3 { get { return "somethingelse"; } }
     }
    
