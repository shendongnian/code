    public class Animal
    {
       private IList<AnimalTrait> _traits;
       public Animal(IList<AnimalTrait> traits)
       {
           _traits = traits;
       }
       public IEnumerable<AnimalTrait> Traits{get{return _traits;}}
    }
    public class AnimalTrait
    {
       public int Value{get;set;}
       public string DisplayName{get;set;}
    }
