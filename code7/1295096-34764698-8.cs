    [Route("api/[controller]")]
    public class MyController : Controller
    {
        public MyDbContext _context { get; set; }
        public MyController([FromServices] MyDbContext context)
        {
			_context = context;
		}
        [HttpGet]
        public async IEnumerable<object> Get()
        {
            var returnObject = new List<dynamic>();
    
            using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "exec dbo.spGetSomeData";
                cmd.CommandType = CommandType.StoredProcedure;
                // set some parameters of the stored procedure
                cmd.Parameters.Add(new SqlParameter("@someParam",
                    SqlDbType.TinyInt) { Value = 1 });
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
    
                var retObject = new List<dynamic>();
                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++) {
                            // one can modify the next line to
                            //   if (dataReader.IsDBNull(iFiled))
                            //       dataRow.Add(dataReader.GetName(iFiled), dataReader[iFiled]);
                            // if one want don't fill the property for NULL
                            // returned from the database
                            dataRow.Add(
                                dataReader.GetName(iFiled),
                                dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                            );
                        }
    
                        retObject.Add((ExpandoObject)dataRow);
                    }
                }
                return retObject;
            }
        }
    }
