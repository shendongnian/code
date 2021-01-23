    public class TheModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool YesOrNo { get; set; }
    }
    int[] ids = new int[5] { 1, 2, 3, 4, 5 };
    string[] names = new string[5] { "John", "Joan", "Bob", "Mark", "Someone" };
    bool[] bools = new bool[5] { true, true, false, true, false };
    
    var wrappedList = new MultiListWrapper<TheModel>(5, ids, names, bools);
