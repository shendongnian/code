    using System.Web.Http;
    using System.Net.Http;
    
    namespace ERP.Controllers.DataAPI
    {
      public class CommunityController : ApiController
      {
        PCSEntities db = new PCSEntities();
    
        public IEnumerable<Community> GetCommunities(Guid ApiKey)
        {
            return db.Communities.AsNoTracking().Take(10);
        }
      }
    }
