    // you could create the locking in this class, but the class1 property is a
    // reference type, so just locking in the property is not enought, it
    // goes wrong when the Class1 has properties itself. (then these will be
    // altered outside the lock..
    // I choose to wrap the whole object and only returning value types
    public class RequiredData
    {
        public Class1 class1 { get; set; }
        public int value1 {get; set;}
    }
    abstract class BaseCommand : ICommand
    {
        // protected.. should not be accessable from the outside..!
        protected static RequiredData RequiredData = new RequiredData();
        public int GetValue()
        {
            lock(RequiredData)
                return RequiredData.value1;
        }
        public string GetSomething()
        {
            // try to avoid returning reference types, but the can be referenced from outside the object.
            lock(RequiredData)
                return RequiredData.Class1.something;
        }
    }
