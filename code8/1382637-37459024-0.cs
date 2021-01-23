    public class Condition
        {
            public string propertyName { get; set; }
            public string propertyValue { get; set; }
            public ICollection<Condition> Conditions { get; set; }
        }
