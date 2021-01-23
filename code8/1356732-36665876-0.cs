       public class Demo : IComparable 
        {
            public string Color;
            public int value;
            public Boolean truth;
            public int CompareTo(Demo other)
            {
                int results = 0;
                if (this.Color == other.Color)
                {
                    if (this.value == other.value)
                    {
                        results = this.truth.CompareTo(other.truth);
                    }
                    else
                    {
                        results = this.value.CompareTo(other.value);
                    }
                }
                else
                {
                    results = this.Color.CompareTo(other.Color);
                }
                return results;
            }
