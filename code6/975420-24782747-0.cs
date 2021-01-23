    public class CustomObject : INotifyPropertyChanged
    {
        //Include properties, constructor, and INotifyPropertyChanged interface members.
        public override bool Equals(object obj)
        {
            CustomObject test = obj as CustomObject;  //test=null if obj cannot be casted.
            if(test == null) return false; //Comparing null against non-null: FALSE
            else
            {   //Check if all properties are equal.
                return ((Property1.CompareTo(test.Property1) == 0) &&
                        (Property2.CompareTo(test.Property2) == 0) &&
                        (Property3.CompareTo(test.Property3) == 0));
            }
        }
    }
