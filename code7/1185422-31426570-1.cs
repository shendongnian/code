    public class Keyclass
    {
        public string Key { get; set; }
    
        public override bool Equals(object other)
        {
          var otherKeyClass = other as Keyclass;
          return (otherKeyClass != null) && (otherKeyClass.Key == Key);
        }
    
        public override int GetHashCode()
        {
          return Key.GetHashCode();
        }
    }
