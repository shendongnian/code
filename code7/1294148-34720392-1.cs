    public class AnotherClass
    {
        private readonly FirstClass collectionHolder;
        
        public AnotherClass(FirstClass collectionHolder)
        {
            this.collectionHolder = collectionHolder;
        }
        public void AddElement()
        {
            var newElement = GetNewElement(); // creates element that will be add to the collection
            collectionHolder.ScheduleDetails.Add(newElement);
        }
    }
