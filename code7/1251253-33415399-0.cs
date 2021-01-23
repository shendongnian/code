    public class TagWithValue
    {
       public string Name { get; set; }
       public double ValueAggrigated { get; set; }
    }
    
    public class RemortTags
    {
       public string Name { get; set; }
       public IEnumerable<TagWithValue> Tags { get; set; }
    }
