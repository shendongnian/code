    public class StaffModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static Func<Staff, StaffModel> Project = item => new StaffModel
        { 
            ID = item.ID,
            Name = item.Name
        };
    }
