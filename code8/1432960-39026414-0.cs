        public class Values1 : BindableBase // Formerly List1
        {
            // Contents unchanged
        }
        public class Values2 : BindableBase // Formerly List2
        {
            // Contents unchanged
        }
        public class Values3 : BindableBase // Formerly List3
        {
            // Contents unchanged
        }
        public class Values1List : ObservableCollection<Values1>
        {
        }
        public class Values2List : ObservableCollection<Values2>
        {
        }
        public class Values3List : ObservableCollection<Values3>
        {
        }
    Your existing naming conventions are misleading as to what is and is not a collection.
    Also, I suggest that you do not nest them inside the `All_Classes` class.  Doing so adds complexity rather than clarity.  
