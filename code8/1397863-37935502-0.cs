    abstract class Requirement 
    {
       abstract public bool Satisfied(User user);
    }
    sealed class Qual1 : Requirement { ... }
    sealed class Qual2 : Requirement { ... }
    ...
    sealed class All : Requirement 
    {
       private IEnumerable<Requirement> r;
       public All(params Requirement[] r) { this.r = r; }
       public All(IEnumerable<Requirement> r) { this.r = r; }
       public override bool Satisfied(User user) {
         return r.All(x => x.Satisfied(user));
       }
    }
    sealed class Any : Requirement 
    {
       ....
