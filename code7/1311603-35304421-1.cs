    public class World
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class WorldCustomMapper : ClassMapper<World>
    {
        public WorldCustomMapper()
        {
            base.Table("hello_world");
            Map(f => f.Id).Column("Id");
            Map(f => f.Value).Column("Value_Column");
        }
    }
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestMappping()
        {
            var conn = new SqlConnection(@"Data Source=.\sqlexpress; Integrated Security=true; Initial Catalog=mydb");
            conn.Open();
            var record = new World
            {
                Id = 1,
                Value = "Hi"
            };
            conn.Insert(record);
            var result = conn.Get<World>(1);
            Assert.That(result.Value, Is.EqualTo("Hi"));
        }
    }
