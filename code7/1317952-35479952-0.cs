        // This endpoint has the structure I would like, but I get duplicates for param1 in the documentation.
        /// <param name="param1">Documentation for param1 (Causes warning since the parameter does not exist in this place.)</param>
        [HttpGet]
        [Route("endpoint2/items/{id}/{param1}")]
        public string GetDataForParameters(int id, [FromUri(Name = "")]MyParams myParams)
        {
            return string.Format("Params: {1}, {2}, {3}", id, myParams.Param1, myParams.Param2, myParams.Param3);
        }
        public class MyParams
        {
            /// <summary>
            /// Documentation here will not be picked up, as it is ignored.
            /// </summary>
            [JsonIgnore]
            public string Param1 { get; set;}
            /// <summary>
            /// This parameter will be documented.
            /// </summary>
            public string Param2 { get; set;}
            public string Param3 { get; set;}
        }
