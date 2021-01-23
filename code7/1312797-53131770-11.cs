        using Microsoft.AspNetCore.Mvc;
        .
        .
        .
        namespace XXX.API.Controllers
        {
            using Microsoft.AspNetCore.Authorization;
            [Authorize]
            [Route("api/[controller]")]
            public class XXXController : Controller
            {
		        .
		        .
		        .
            }
        }
