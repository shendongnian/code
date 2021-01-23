    class HazGeo
    {
        public int Id { get;set; }
        public DbGeography Geo { get; set; }
    }
    public void DBGeography_SO24405645_SO24402424()
    {
        global::Dapper.SqlMapper.AddTypeHandler(typeof(DbGeography), new GeographyMapper());
        connection.Execute("create table #Geo (id int, geo geography)");
        var obj = new HazGeo
        {
            Id = 1,
            Geo = DbGeography.LineFromText("LINESTRING(-122.360 47.656, -122.343 47.656 )", 4326)
        };
        connection.Execute("insert #Geo(id, geo) values (@Id, @Geo)", obj);
        var row = connection.Query<HazGeo>("select * from #Geo where id=1").SingleOrDefault();
        row.IsNotNull();
        row.Id.IsEqualTo(1);
        row.Geo.IsNotNull();
    }
    class GeographyMapper : Dapper.SqlMapper.TypeHandler<DbGeography>
    {
        public override void SetValue(IDbDataParameter parameter, DbGeography value)
        {
            parameter.Value = value == null ? (object)DBNull.Value : (object)SqlGeography.Parse(value.AsText());
            ((SqlParameter)parameter).UdtTypeName = "GEOGRAPHY";
        }
        public override DbGeography Parse(object value)
        {
            return (value == null || value is DBNull) ? null : DbGeography.FromText(value.ToString());
        }
    }
