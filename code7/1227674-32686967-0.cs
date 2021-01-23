    public class Entity
    {
       public int ID { get; set; }
       [JsonIgnore]
       public Entity Parent { get; set; }
       ...
    }
