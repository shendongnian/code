    public class CustomResolver : ValueResolver<One, List<string>>
	{
		protected override List<string> ResolveCore(One source)
		{
			var result = new List<string>();
			
			//your logic
			if (!string.IsNullOrWhiteSpace(source.S1))
				result.Add(source.S1);
				
			if (!string.IsNullOrWhiteSpace(source.S2))
				result.Add(source.S2);
				
			if (!string.IsNullOrWhiteSpace(source.S3))
				result.Add(source.S3);
				
			if (!string.IsNullOrWhiteSpace(source.S4))
				result.Add(source.S4);
				
			return result;
		}
	}
	
