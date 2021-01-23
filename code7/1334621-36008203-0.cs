    public class OnlyDogsAndCatsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        => (value as IList<string>).All(s => s == "Dog" || s == "Cat"); 
    }
    
    public class Animal
    {
       [OnlyDogsAndCatsAttribute]
       public List<string> Animals { get; set; }
    }
