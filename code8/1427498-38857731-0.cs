	public class ResRepository : IResRepository
	{
		// marked as async
		public async Task<ClientResponse> GetClientBySSN(string ssn)
		{
			// missing await - also use await and get result directly instead of getting the task and then awaiting it
			int clientNumber = await _service.GetClientNumberBySSN(ssn);
			if (clientNumber != null)
			{
				//another async method that uses ID from the first result
				// change - missing await
				return await _service.GetClientDetailsByClientNumber(clientNumber);
			}
			else
			{
				return null;
			}
		}
	}
