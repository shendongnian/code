    public interface IProvider<T>
    {
      public T Current {get; set;}
    }
           
    public class DietProvider : IProvider<IDiet>
    {
      public IDiet Current {get; set;}
    }
        
    class Human : IDiet
    {
      private readonly IProvider<IDiet> _dietProvider;
    
      public Human(IProvider<IDiet> dietProvider)
      {
        _dietProvider = dietProvider;
      }
    
      public void Eat()
      {
        _dietProvider.Current.Eat();
      }
    }
    
    void Main()
    {
      IProvider<IDiet> dietProvider= new DietProvider { Current = new CarnivoreDiet()};
      Human human = new Human(dietProvider);
      human.Eat();
      // outputs "Eat chicken"
      dietProvider.Current = new HerbivoreDiet();
      human.Eat();
    }
    
