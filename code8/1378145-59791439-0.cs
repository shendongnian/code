    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    
    namespace CodingMachine
    {
        public class MyService
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly LinkGenerator _generator;
    
            public MyService(IHttpContextAccessor accessor, LinkGenerator generator)
            {
                _accessor = accessor;
                _generator = generator;
            }
    
            private string GenerateConfirmEmailLink()
            {
                var callbackLink = _generator.GetUriByPage(_accessor.HttpContext,
                    page: "/Account/ConfirmEmail",
                    handler: null, 
                    values: new {area = "Identity", userId = 123, code = "ASDF1234"});
    
                return callbackLink;
            }
        }
    }
