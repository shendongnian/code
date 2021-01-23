    class Base
    {
       protected MemberClass MemberProperty { get; }    
       public Base(MemberClass memberValue)
       {
           this.MemberProperty = memberValue;
       }
    
       // methods accessing MemberProperty...
    }
