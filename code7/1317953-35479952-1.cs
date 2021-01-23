        /// <param name="param1">URL parameters must be documented on this level.</param>
        [HttpGet]
        [Route("endpoint2/items/{id}/{param1}")]
        public string GetDataForParameters(int id, string param1, [FromUri(Name = "")]MyParams myParams)
        {
            // the param1 method parameter is a dummy, and not used anywhere.
            return string.Format("Params: {1}, {2}, {3}", id, myParams.Param1, myParams.Param2, myParams.Param3);
        }
        public class MyParams
        {
            /// <summary>
            /// Cannot add documentation here, it will be ignored.
            /// </summary>
            [JsonIgnore]
            public string Param1 { get; set;}
            /// <summary>
            /// This is included. Querystring parameters can be documented in this class.
            /// </summary>
            public string Param2 { get; set;}
            public string Param3 { get; set;}
        }
