    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.Http.Features;
    public class Foo
    {
		public Foo(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext;
        }
        private readonly HttpContext _context;
		
		public bool TokenCorrect()
		{
			ISessionFeature sessionFeature = _context.Features.Get<ISessionFeature>();
			if(sessionFeature != null)
			{
				int? token = sessionFeature.Session.GetInt32("Token");
				if(token.HasValue)
				{
					// do whatever check you are doing
				}
			}
			
			return false;
		}
    }
