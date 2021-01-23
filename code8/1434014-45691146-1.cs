json
{
	"ConnectionStrings": {
		"YourConnection": "Data Source=.\\SqlExpress;Initial Catalog=DatabaseName;Integrated Security=True;"
	}
}
c#
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
	public class YourTestServicesShould
	{
		private YourContext _yourContext; //TODO DI
		public IConfigurationRoot Configuration { get; set; }
		[Fact]
		public void Save_WhenGivenAValidOrderItem()
		{
			//Arrange
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
			Configuration = builder.Build();
			var optionsBuilder = new DbContextOptionsBuilder<_yourContext>();
			optionsBuilder.UseSqlServer(Configuration.GetConnectionString("YourConnection"));
			_yourContext= new YourContext(optionsBuilder.Options);
	....
   }
}
