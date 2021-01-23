    using MailChimp;
    using MailChimp.Helper;
    using Opten.Polyglott.Web.Models;
    using Opten.Umbraco.Common.Extensions;
    using System.Configuration;
    using System.Web.Http;
    using Umbraco.Core.Logging;
    using Umbraco.Web.WebApi;
    
    namespace Opten.Polyglott.Web.Controllers
    {
        public class NewsletterApiController : UmbracoApiController
        {
            public IHttpActionResult Subscribe(Newsletter newsletter)
            {
                bool isSuccessful = false;
                if (ModelState.IsValid)
                {
                    isSuccessful = SubscribeEmail(newsletter.Email);
                }
    
                return Json(new { isSuccess = isSuccessful });
            }
        }
    }
