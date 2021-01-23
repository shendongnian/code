    // entity
    public class Stooge
    {
       public Stooges MoronInQuestion {get;set;}
       public double MoeEnragementFactor {get;set;}
       public void PloinkEyes() { /*snip*/ }
       public void Slap() { /*snip*/ }
       public void Punch() { /*snip*/ }
       // etc
    }
    
    // enum for an Id? It's not that crazy, sometimes
    public enum Stooges
    {
        Moe = 1,
        Larry = 2,
        Curly = 3,
        Shemp = 4,
        Joe = 5,
        /* nobody likes Joe DeRita */
        //CurlyJoe = -1, 
    }
    // implementation
    public class StoogeRepository : IRepository<Stooge>
    {
        public override int GetId(Stooge entity)
        {
            if(entity == null)
                throw new WOOWOOWOOException();
            return (int)entity.MoronInQuestion;
        }
    }
