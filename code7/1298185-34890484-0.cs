    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.OData;
    using ParadiseBayDataService.Models;
    
    namespace ParadiseBayDataService.Controllers
    {
        [EnableQuery]
        public class CropsController : ODataController
    
        {
            private ParadiseDataContext db = new ParadiseDataContext();
    
            // GET: odata/Crops
            [EnableQuery]
            public IQueryable<Crop> GetCrops()
            {
                return db.Crops;
            }
