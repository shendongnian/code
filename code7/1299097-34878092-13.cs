    public class MyTabItemViewModel 
    {
        public ICommand MyCommand { get; set; }
        public MyTabItemViewModel(ParentVM parent)
        {
            MyCommand = new DeleteCommand(parent, this);
        }
        ...
    }
 
