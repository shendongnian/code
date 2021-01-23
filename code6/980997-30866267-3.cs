    using Newtonsoft.Json;
    
    namespace Data.Models
    {
        public class Neo4jRelationship
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            [JsonIgnore]
            public string Name { get; set; }
    
            public Neo4jRelationship()
            {
            }
        }
    }
