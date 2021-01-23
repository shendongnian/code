    public abstract class AbstractModel : ObservableObject
    {
        // no property
        
        protected string Prefix(object data)
        {
           if (ReferenceEquals(data, null))
             return string.Empty;
           string result = data.ToString();
           if (data.Contains(",") || data.Contains("\""))
             return $"\"{data}\"";
           return data;
        }
    }
    
    public class RealModel : AbstractModel 
    {
        public string PropertyA {get; set;}
        public string PropertyB {get; set;}
        public override string ToString()
        {
           return $"{Prefix(PropertyA)},{Prefix(PropertyB)}";
        }
    }
