    public void SO24607639_NullableBools()
    {
        var obj = connection.Query<HazBools>(
            @"declare @vals table (A bit null, B bit null, C bit null);
            insert @vals (A,B,C) values (1,0,null);
            select * from @vals").Single();
        obj.IsNotNull();
        obj.A.Value.IsEqualTo(true);
        obj.B.Value.IsEqualTo(false);
        obj.C.IsNull();
    }
    class HazBools
    {
        public bool? A { get; set; }
        public bool? B { get; set; }
        public bool? C { get; set; }
    }
