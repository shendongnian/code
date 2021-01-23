    public abstract class Variance
    {
        public string Prop { get; set; }
        
        public string GetChangedFromText() { return this.GetChangedFromText(null); }
        protected abstract string GetChangedFromText(string parent);
        public class ValueVariance<T> : Variance
        {
            public object valA { get; set; }
            public object valB { get; set; }
        
            protected override string GetChangedFromText(string parent)
            {
                return "value of " + (parent??"<root>") + "." + this.Prop + " has changed from " + this.valA + " to " + this.valB;
            }
        }
        public class EnumerableVariance : Variance
        {
            public List<Variance> variances   = new List<Variance>();
        
            protected override string GetChangedFromText(string parent)
            {
                StringBuilder   returnString    = new StringBuilder();
                foreach(var variance in this.variances)
                {
                    returnString.Append(variance.GetChangedFromText(this.Prop));
                }
                return returnString.ToString();
            }
        }
        public class KeylessObjectEnumerableVariance : Variance
        {
            public int listACount;
            public int listBCount;
            protected override string GetChangedFromText(string parent)
            {
                return "count of keyless items " + (parent??"<root>") + "." + this.Prop + " has changed from " + this.listACount.ToString() + " to " + this.listBCount.ToString();
            }
        }
        public class ValueRemovedVariance<T> : Variance
        {
            public T value;
            protected override string GetChangedFromText(string parent)
            {
                return "value " + this.value.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was removed.";
            }
        }
        public class ValueAddedVariance<T> : Variance
        {
            public T value;
            protected override string GetChangedFromText(string parent)
            {
                return "value " + this.value.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was added.";
            }
        }
        public class KeyedObjectRemovedVariance<T> : Variance
        {
            public T key;
            protected override string GetChangedFromText(string parent)
            {
                return "key " + this.key.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was removed.";
            }
        }
        public class KeyedObjectAddedVariance<T> : Variance
        {
            public T key;
            protected override string GetChangedFromText(string parent)
            {
                return "key " + this.key.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was added.";
            }
        }
    }
