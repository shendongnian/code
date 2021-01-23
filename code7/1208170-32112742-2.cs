    public abstract class Car<TCar> where TCar : Car<TCar>
    {
        public virtual void Copy(TCar car)
        {
            // stuff //
        }
    }
    
    
    public class Ford : Car<Ford>
    {
        public override void Copy(Ford updatedFord) {}
    }
    
    public class Holden  : Car<Holden>
    {
        public override void Copy(Holden updatedHolden) { .. }
    }
