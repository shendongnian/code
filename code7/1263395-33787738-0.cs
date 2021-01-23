    public class InMemoryDatabase
    {
        public HashSet<TEntity> GetCollection<TEntity>()
        {
            var a = this.GetType().GetProperties();
            HashSet<TEntity> retVal = null;
            foreach (var name in a.Select(propertyInfo => propertyInfo.Name))
            {
                retVal = this.GetType().GetProperty(name).GetValue(this, null) as HashSet<TEntity>;
                if (retVal != null)
                {
                    break;
                }
            }
    
            return retVal;
        }
        public HashSet<Car> Cars { get; set; }
        public HashSet<Truck> Trucks { get; set; }
        public HashSet<Bike> Bikes { get; set; }    
    }
