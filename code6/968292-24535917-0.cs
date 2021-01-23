    public abstract class Integr<T>
    {
        public abstract IList<T> GetRefills();
    }
    
    public class TMTStandard : Integr<TMTStandardRefill>
    {
        public override IList<TMTStandardRefill> GetRefills()
        {
            // ...
        }
    }
