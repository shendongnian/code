	using AspNetCore.Security.Jwt;
	using System.Threading.Tasks;
	namespace XXX.API
	{
		public class Authenticator : IAuthentication
		{        
			public async Task<bool> IsValidUser(string id, string password)
			{
				//Put your id authenication here.
				return true;
			}
		}
	}
