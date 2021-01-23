    public class DogDto
    {
        public int? Age { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
    
        public int IgnoredProperty { get { return 1; } }
    }   
   
    // _databaseConnectionString is your database connection string
    using (var conn = new SqlConnection(_databaseConnectionString)){
    var dog = cnn.Query<DogDto>("schema.spGetDog", new {Id = 120}, 
            commandType: CommandType.StoredProcedure).SingleOrDefault();
     }
    // and let's assume we have schema.spGetDog stored procedure already declared in our database 
