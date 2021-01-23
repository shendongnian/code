    public class CustomObject
    {
    }
    public class CustomObjectList
    {
        public static ObservableCollection<CustomObject> List = new ObservableCollection<CustomObject>();
        // Instance property
        public CustomObject NonStaticCustomObject { get; set; }
        // Static property
        public static CustomObject StaticCustomObject { get; set; }
        public void OnOpen()
        {
            // This is a reference of the new object added to the collection scoped to the method.
            var newCustomObject = new CustomObject();
            // Add it to the list
            List.Add(newCustomObject);
            // Store as a static reference
            CustomObjectList.StaticCustomObject = newCustomObject;
            // Store as an instance reference
            NonStaticCustomObject = newCustomObject;
        }
       
        public void OnClose()
        {
        }
    }
    public class SomeOtherClass
    {
        public void UseList()
        {
            var customList = new CustomObjectList();
            
            customList.OnOpen();
            
            // We can get access to the static reference like this.
            var itemFromStatic = CustomObjectList.StaticCustomObject;
            // We can get access to the non static reference like this.
            var itemFromInstance = customList.NonStaticCustomObject;
        }
    }
