    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Core;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ServerSentEventController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
