    public class A<BC> where BC : BaseClass
    {
       public BC BaseClassProperty {get; set;}
    }
    
    public class B : A<FinalClass>
    { }
