    public class ItemRate : IEquatable<ItemRate>
            {
                public int Id { get; set; }
                public int ItemId { get; set; }
                public float straightTime { get; set; }
                public float overTime { get; set; }
    
                public bool Equals(ItemRate obj)
                {
                    if (obj == null)
                        return false;
    
                    if (obj.Id == this.Id)
                        return true;
    
                    return false;
                }
            }
    
        
    public class Item : IEquatable<Item>
            {
                public int Id { get; set; }
                public string Description { get; set; }
                public List<ItemRate> Rates { get; set; }
    
                public bool Equals(Item obj)
                {
                    if (obj == null)
                        return false;
    
                    if (obj.Id == this.Id)
                        return true;
    
                    return false;
                }
            }
