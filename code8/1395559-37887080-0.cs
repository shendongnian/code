    public class Example
    {
        public string Name { get; set; }
        [Decompose("Mother_")]
        public Person Mother { get; set; }
        [Decompose("Father_")]
        public Person Father { get; set; }
    }
    SELECT x.nName, m.FirstName as Mother_FirstName, f.FirstName as Father_FirstName, [...] 
    FROM people x
    LEFT JOIN people f ON x.FatherKey = f.Key
    LEFT JOIN people m ON x.MotherKey = m.Key
