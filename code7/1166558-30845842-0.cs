    [TestFixture]
    public class SoTest
    {
        [Test]
        public void Test1()
        {
            var departments = new List<Department>
            {
                new Department
                {
                    DeptId = 1
                }
            };
            var sportList = new List<Sport>
            {
                new Sport
                {
                    DeptId = 1,
                    SportId = 1,
                    SportName = "Basketball"
                },
                new Sport
                {
                    DeptId = 1,
                    SportId = 2,
                    SportName = "Tennis"
                }
            };
            var sportsEntries = new Dictionary<byte, List<Kvp>>();
            foreach (var department in departments)
            {
                var deptOptions = sportList
                    .Where(x => x.DeptId == department.DeptId)
                    .Select(x => new Kvp { Value = x.SportId, Text = x.SportName }).ToList();
                sportsEntries.Add(department.DeptId, deptOptions);
            }
            string json = JsonConvert.SerializeObject(sportsEntries);
            Assert.IsNotNullOrEmpty(json);
            Debug.Print(json);
        }
    }
    public class Department
    {
        public byte DeptId { get; set; }
    }
    public class Sport
    {
        public byte DeptId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
    }
    [DataContract]
    public class Kvp
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }
        
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
