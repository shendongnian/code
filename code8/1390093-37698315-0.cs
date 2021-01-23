    public class TestObj : IComparable<TestObj>
    {
        public string Name { get; set; }
        public SomeAction Action { get; set; }
        public string Value { get; set; }
        public TestObj(string name, SomeAction action, string value)
        {
            Name = name;
            Action = action;
            Value = value;
        }
        public enum SomeAction
        {
            Read = 0,
            Create = 1,
            Update = 2,
            Delete = 3,
            Download = 4,
            Archive = 5,
            Restore = 6
        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Action: {1}, Value: {2}", Name, Action.ToString(), Value);
        }
        public int CompareTo(TestObj obj)
        {
            return this.Action.CompareTo(obj.Action);
        }
    }
