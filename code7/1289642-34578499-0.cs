    using System.Collections.Generic;
    using System.Web.Http;
    using System.Linq;
    namespace WebApplication3.Areas.api.Controllers
    {
        public class MountainController : ApiController
        {
            static Dictionary<int, string> data;
            static Dictionary<int, int> dataCounter;
            static MountainController()
            {
                data = Enumerable.Range(1, 10).ToDictionary(i => i, i => "Mountain " + i.ToString());
                dataCounter = Enumerable.Range(1, 10).ToDictionary(i => i, i => 0);
            }
            [HttpGet]
            public MountainModel GetMountain(int id)
            {
                string mountainName = data[id];
                dataCounter[id] = dataCounter[id] + 1;
                return new MountainModel() { Id = id, Name = mountainName, Count = dataCounter[id] };
            }
        }
        public class MountainModel
        {
            public int Count { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
