	public class ResRepository : IResRepository
	{
		// missing async
		public async Task<ClientResponse> GetClientBySSN(string ssn)
		{
			// missing await - also use await and get result directly instead of getting the task and then awaiting it
			var client = await _service.GetClientNumberBySSN(ssn);
			// type int can never be null, this will never eval to false. maybe you meant int? above
			// I changed to to client null check instead, maybe that is what you were going for
			if (client != null)
			{
				//another async method that uses ID from the first result
				// change - missing await
				return await _service.GetClientDetailsByClientNumber(client.clientNumber);
			}
			else
			{
				return null;
			}
		}
	}
