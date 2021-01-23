      public class MyAuth
      {
         private readonly RequestDelegate _next;
         public MyAuth(RequestDelegate next)
         {
            _next = next;
         }
         public async Task Invoke(HttpContext context)
         {
            try
            {
               // grab stuff from the HttpContext
               string authHeader = context.Request.Headers["Authorization"] ?? "";
               string path = context.Request.Path.ToString() ?? "";
               // add an identity to the user that specifies what 
               // we'll validate against for our authentication type
               Claim[] claims = 
               {
                  new Claim(ClaimTypes.Authentication, authHeader),
                  new Claim(ClaimTypes.Uri, path)
               };
               var identity = new ClaimsIdentity(claims, "MyAuth");
               context.User.AddIdentity(identity);
            }
            finally
            {
               await _next(context);
            }
         }
      }
