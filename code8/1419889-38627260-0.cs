    void Main()
    {
        var componentsIndex = "components";
    	var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var settings = new ConnectionSettings(connectionPool)
            // use component index when working with
            // Component Poco type
            .InferMappingFor<Component>(m => m
                .IndexName(componentsIndex)
            );
    
        var client = new ElasticClient(settings);
        
        // make this example repeatable, so delete index if
        // it already exists
        if (client.IndexExists(componentsIndex).Exists)
            client.DeleteIndex(componentsIndex);
    
        // for example purposes, only use one shard and no replicas
        // NOT RECOMMENDED FOR PRODUCTION
        client.CreateIndex(componentsIndex, c => c
            .Settings(s => s
                .NumberOfShards(1)
                .NumberOfReplicas(0)
            )
        );
    
        client.Map<Component>(d => d
            .Index(componentsIndex)
            // infer mapping of fields from property of the POCO.
            // This means we don't need to explicitly specify all 
            // mappings in .Properties()
            .AutoMap()
            // Now, override any inferred mappings from automapping
            .Properties(props => props
                .Completion(c => c
                    .Name(n => n.ComponentSuggestion)
                    .Context(context => context
                        .Category("projectId", cat => cat
                            .Field(field => field.ProjectId)
                        )
                    )
                    .Payloads()
                )
                .String(s => s
                    .Name(n => n.Id)
                    .NotAnalyzed()
                )
                .String(s => s
                    .Name(n => n.ProjectId)
                    .NotAnalyzed()
                )
            )
        );
        
        var components = new[] {
            new Component
            {
                Id = "1",
                Name = "Component Name 1",
                ComponentSuggestion = new CompletionField<object>
                {
                    Input = new [] { "Component Name 1" },
                    Output = "Component Name 1"
                },
                ProjectId = "project_id"
            },
            new Component
            {
                Id = "2",
                Name = "Component Name 2",
                ComponentSuggestion = new CompletionField<object>
                {
                    Input = new [] { "Component Name 2" },
                    Output = "Component Name 2"
                },
                ProjectId = "project_id_2"
            }
        };
        
        // index some components with different project ids
        client.IndexMany(components);
        // refresh the index to make the newly indexed documents available for
        // search. Useful for demo purposes but,
        // TRY TO AVOID CALLING REFRESH IN PRODUCTION     
        client.Refresh(componentsIndex);
    
        var projectId = "project_id";
    
        var suggestResponse = client.Suggest<Component>(s => s
            .Index(componentsIndex)
            .Completion("suggester", c => c
                .Field(f => f.ComponentSuggestion)
                .Text("Compon")
                .Context(con => con.Add("projectId", projectId))
                .Size(20)
            )
        );
    
        foreach (var suggestion in suggestResponse.Suggestions["suggester"].SelectMany(s => s.Options))
        {
            Console.WriteLine(suggestion.Text);
        }
    }
    
    public class Component
    {
        public string Id { get; set; }
    
        public string Name { get; set; }
        
        public string ProjectId { get; set; }
    
        public CompletionField<object> ComponentSuggestion { get; set; }
    }
