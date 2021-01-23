    [RoutePrefix("api/v1/fighters")]
    public class FighterController : ApiController
    {
        /// <summary>
        /// Gets all fighters.
        /// </summary>
        /// <returns>An enumeration of fighters.</returns>
        [Route(""), HttpGet]
        public IEnumerable<Fighter> GetAllFighters()
        {
            return allFighters;
        }
    
        /// <summary>
        /// Gets all fighters that are currently undefeated.
        /// </summary>
        /// <returns>An enumeration of fighters.</returns>
        [Route("undefeated"), HttpGet]
        public IEnumerable<Fighter> GetAllUndefeatedFighters()
        {
            return allFighters.FindAll(f => f.MMARecord.Losses == 0);
        }
    }
