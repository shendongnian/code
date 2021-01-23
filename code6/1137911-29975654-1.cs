    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.OData; // OData V3
    using System.Web.Http.OData.Query;
    using Microsoft.Data.OData;
    using MyProject;
    
    namespace MyProject.Controllers
    {
        public class MarvelCharactersV3Controller : ODataController
        {
            private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
    
            // GET: odata/MarvelCharacters
            public IHttpActionResult GetMarvelCharactersV3(ODataQueryOptions<MarvelCharacter> queryOptions)
            {
                // validate the query.
                try
                {
                    queryOptions.Validate(_validationSettings);
                }
                catch (ODataException ex)
                {
                    return BadRequest(ex.Message);
                }
    
                var entities = new myEntities();
                var marvelCharacters = (from c in entities.MarvelCharacters select c).ToList();
    
                return Ok<IEnumerable<MarvelCharacter>>(marvelCharacters);
            }
        }
    }
