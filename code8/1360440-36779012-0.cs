    public class MuhViewModel
    {
        public MuhItems[] MuhItems {get;} = new[]{ new Item(1), new Item(2) };
    
        // I don't want to show INPC impls in my sample code, kthx
        [SuperSlickImplementINotifyPropertyChangedAttribute]
        public MuhSelectedItem {get;set;}
    }
