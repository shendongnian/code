    public class SomeClass : ICloneable
    {
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public SomeClass Clone()
        {
            SomeClass otherInstance = new SomeClass();
            // do the cloning here
            otherInstance.Property = this.Property;
            // end
            return otherInstance;
        }
    }
