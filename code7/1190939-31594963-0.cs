    public class Dog : Animal
    {}
    
    public class Animal : IHaveCreateDate // IHaveBirthDate would be more suitable here ;-)
    {
        DateTime CreateDate { get; set; }
    }
