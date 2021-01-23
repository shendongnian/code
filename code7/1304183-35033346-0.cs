    public class InfraestructuraComparer: IEqualityComparer<INFRAESTRUCTURA>
    {
        public bool Equals(INFRAESTRUCTURA x, INFRAESTRUCTURA y)
        {
            // Your equality logic goes to here
            return x.ID == y.ID;
        }
    
        public int GetHashCode(INFRAESTRUCTURA obj)
        {
            unchecked
            {
                var hash = 17;
    
                hash = hash * 23 + obj.Id.GetHashCode();
    
                return hash;    
            }
        }
    }
