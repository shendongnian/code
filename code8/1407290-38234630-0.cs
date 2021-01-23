    var user = connection.Query("spGetUser", commandType: CommandType.StoredProcedure)
			.Select(x =>
			{
				var result = new Customer { ID = x.Id };
				foreach (var element in x)
				{
					if (element.Key.Contains("Email"))
						result.EmailAddresses.Add(element.Value.ToString());
				}
				return result;
			}).FirstOrDefault();
    public class Customer
    {
    	public int ID { get; set; }
    	public List<string> EmailAddresses { get; set; } = new List<string>();
    }
