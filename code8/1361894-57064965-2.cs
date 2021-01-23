public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddDbContext<MyDbContext>();
    ...
***MyDbContext Class***
public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (DbManager.DbName != null && !optionsBuilder.IsConfigured)
        {
            var dbName = DbManager.DbName;
            var dbConnectionString = DbManager.GetDbConnectionString(dbName);
            optionsBuilder.UseMySql(dbConnectionString);
        }
    }
    ...
***Json*** - File that has a Connection Info
[
  {
    "name": "DB1",
    "dbconnection": "server=localhost;port=3306;user=username;password=password;database=dbname1"
  },
  {
    "name": "DB2",
    "dbconnection": "server=localhost;port=3306;user=username;password=password;database=dbname2"
  }
]
***DbConnection Class***
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
public class DbConnection
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("dbconnection")]
    public string Dbconnection { get; set; }
    public static List<DbConnection> FromJson(string json) => JsonConvert.DeserializeObject<List<DbConnection>>(json, Converter.Settings);
}
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
***DbConnectionManager Class***
public static class DbConnectionManager
{
    public static List<DbConnection> GetAllConnections()
    {
        List<DbConnection> result;
        using (StreamReader r = new StreamReader("myjsonfile.json"))
        {
            string json = r.ReadToEnd();
            result = DbConnection.FromJson(json);
        }
        return result;
    }
    public static string GetConnectionString(string dbName)
    {
        return GetAllConnections().FirstOrDefault(c => c.Name == dbName)?.Dbconnection;
    }
}
***DbManager Class***
public static class DbManager
{
    public static string DbName;
    
    public static string GetDbConnectionString(string dbName)
    {
        return DbConnectionManager.GetConnectionString()dbName;
    }
}
Then, you would need some controller that set ***dbName*** up.
***Controller Class***
[Route("dbselect/{dbName}")]
public IActionResult DbSelect(string dbName)
{
    // Set DbName for DbManager.
    DbManager.DbName = dbName;
    dynamic myDynamic = new System.Dynamic.ExpandoObject();
    myDynamic.DbName = dbName;
    var json = JsonConvert.SerializeObject(myDynamic);
    return Content(json, "application/json");
}
You might have to do some trick something here and there. but you will get the Idea. At the beginning of the app, It doesn't have connection detail. so you have to set it up explicitly using Controller. Hope this will help someone.
