    public class EntityList : List<Entity>
    {
    
        public void Add(Entity entity)
        {
    
            if (this.Any(n => n.OrderNumber == entity.OrderNumber && n.TrackingNumber == entity.TrackingNumber))
                return;
    
            base.Add(entity);
    
        }
    
    }
