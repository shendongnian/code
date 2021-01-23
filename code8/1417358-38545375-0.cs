        /// <summary>
        /// Gets all fighters.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllFighters")]
        [System.Web.Http.Route("api/GetAllFighters")]
        public IEnumerable<Fighter> GetAllFighters()
        {
            return allFighters;
        }
    
        /// <summary>
        /// Gets all fighters that are currently undefeated.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllUndefeatedFighters")]
        [System.Web.Http.Route("api/GetAllUndefeatedFighters")]
        public IHttpActionResult GetAllUndefeatedFighters()
        {
            var results = allFighters.FindAll(f => f.MMARecord.Losses == 0);
    
            if (results == null)
            {
                return NotFound();
            }
    
            return Ok(results);
        }
