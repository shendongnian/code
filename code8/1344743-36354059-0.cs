    [FactMySql]
    public void SO36303462_Tinyint_Bools()
    {
        using (var conn = GetMySqlConnection(true, true, true))
        {
            try { conn.Execute("drop table SO36303462_Test"); } catch { }
            conn.Execute("create table SO36303462_Test (Id int not null, IsBold tinyint not null);");
            conn.Execute("insert SO36303462_Test (Id, IsBold) values (1,1);");
            conn.Execute("insert SO36303462_Test (Id, IsBold) values (2,0);");
            conn.Execute("insert SO36303462_Test (Id, IsBold) values (3,1);");
            var rows = conn.Query<SO36303462>("select * from SO36303462_Test").ToDictionary(x => x.Id);
            rows.Count.IsEqualTo(3);
            rows[1].IsBold.IsTrue();
            rows[2].IsBold.IsFalse();
            rows[3].IsBold.IsTrue();
        }
    }
    class SO36303462
    {
        public int Id { get; set; }
        public bool IsBold { get; set; }
    }
