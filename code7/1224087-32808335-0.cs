    public class ExpandableCollectionPropertyDescriptor : PropertyDescriptor
    {
        // Subscribe to this event from the form with the property grid
        public static event EventHandler CollectionChanged;
        // Tuple elements: The owner of the list, the list, the serialized content of the list
        // The reference to the owner is a WeakReference because you cannot tell the
        // PropertyDescriptor that you finished the editing and the collection
        // should be removed from the list.
        // Remark: The references here may survive the property grid's life
        private static List<Tuple<WeakReference, IList, byte[]>> collections;
        private static Timer timer;
        public ExpandableCollectionPropertyDescriptor(ITypeDescriptorContext context, IList collection, ...)
        {
            AddReference(context.Instance, collection);
            // ...
        }
        private static void AddReference(object owner, IList collection)
        {
            // TODO:
            // - serialize the collection into a byte array (BinaryFormatter) and add it to the collections list
            // - if this is the first element, initialize the timer
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // TODO: Cycle through the collections elements
            // - If WeakReference is not alive, remove the item from the list
            // - Serialize the list again and compare the result to the last serialized content
            // - If there a is difference:
            //   - Update the serialized content
            //   - Invoke the CollectionChanged event. The sender is the owner (WeakReference.Target).
        }
    }
