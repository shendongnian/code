    public abstract class Entity<T>
    {
      protected abstract bool IsEqual(T other);
    }
    public class Person : Entity<Person>
    {
      protected override bool IsEqual(Person other) { ... }
    }
