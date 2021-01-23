    public class Review
        {
            public string Name { get; set; }
            public int Amount { get; set; }
    
            public override bool Equals(System.Object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }
    
    
                Review r = obj as Review;
                if ((System.Object)r == null)
                {
                    return false;
                }
    
                //only compare on the name.
                return Name.Equals(r.Name);
            }
        }
