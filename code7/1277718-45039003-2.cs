	namespace Brass9.OwinVisitor.Auth
	{
		public class ReducedClaims
		{
			protected Dictionary<string, string> claims;
			public ReducedClaims(IEnumerable<System.Security.Claims.Claim> claims)
			{
				var _claims = claims.ToArray();
				this.claims = new Dictionary<string, string>(_claims.Length);
				foreach(var claim in _claims)
				{
					this.claims.Add(claim.Type, claim.Value);
				}
			}
			public ReducedClaims(ExternalLoginInfo loginInfo)
				: this(loginInfo.ExternalIdentity.Claims)
			{}
			//http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname
			//http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname
			protected string chainValue(params string[] keys)
			{
				string val = null;
				foreach(var key in keys)
				{
					if (claims.TryGetValue(key, out val))
						return val;
				}
				return val;
			}
			// TODO: Instead detect which service it is then use the proper string instead of just milling through guesses?
			public string FirstName { get { return chainValue(
				"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname",	// Google
				"urn:facebook:first_name"	// Facebook
			); } }
			public string LastName { get { return chainValue(
				"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname",	// Google
				"urn:facebook:last_name"	// Facebook
			); } }
		}
	}
