    public class FlatItem {
        public int ID;
        public int groupFlag;
        public int? fatherID;
        public string Name;
    }
    var data = new List<FlatItem>();
    data.Add(new FlatItem() { ID = 1, groupFlag = 1, fatherID = null, Name = "Group 1" });
    data.Add(new FlatItem() { ID = 2, groupFlag = 1, fatherID = 1, Name = "Group 1.1" });
    data.Add(new FlatItem() { ID = 3, groupFlag = 0, fatherID = 2, Name = "Entry 1" });
    data.Add(new FlatItem() { ID = 4, groupFlag = 0, fatherID = 2, Name = "Entry 2" });
    data.Add(new FlatItem() { ID = 5, groupFlag = 1, fatherID = null, Name = "Group 2" });
    data.Add(new FlatItem() { ID = 6, groupFlag = 0, fatherID = 5, Name = "Entry 3" });
