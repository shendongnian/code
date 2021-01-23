    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    using Rally.RestApi.Json;
    
    namespace GetByRefExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                RallyRestApi restApi = new RallyRestApi(webServiceVersion: "v2.0");
                String apiKey = "_abc123";
                restApi.Authenticate(apiKey, "https://rally1.rallydev.com", allowSSO: false);
                String workspaceRef = "/workspace/123";
                String projectRef = "/project/456";  
    
                Request request = new Request("PortfolioItem/Feature");
                request.Fetch = new List<string>() { "Name", "FormattedID" };
                request.Query = new Query("FormattedID", Query.Operator.Equals, "F2356");
                QueryResult result = restApi.Query(request);
    
                String featureRef = result.Results.First()._ref;
                Console.WriteLine("found" + featureRef);
    
                //create stories
                try
                {
                    for (int i = 1; i <= 25; i++)
                    {
                        DynamicJsonObject story = new DynamicJsonObject();
                        story["Name"] = "story " + i;
                        story["PlanEstimate"] = new Random().Next(2,10);
                        story["PortfolioItem"] = featureRef;
                        story["Project"] = projectRef;
                        CreateResult createResult = restApi.Create(workspaceRef, "HierarchicalRequirement", story);
                        story = restApi.GetByReference(createResult.Reference, "FormattedID");
                        Console.WriteLine("creating..." + story["FormattedID"]);
                    }
                //read stories
                    DynamicJsonObject feature = restApi.GetByReference(featureRef, "UserStories");
                    Request storiesRequest = new Request(feature["UserStories"]);
                    storiesRequest.Fetch = new List<string>()
                    {
                        "FormattedID",
                        "PlanEstimate"
                    };
                    storiesRequest.Limit = 1000;
                    QueryResult storiesResult = restApi.Query(storiesRequest);
                    int storyCount = 0;
                    foreach (var userStory in storiesResult.Results)
                    {
                        Console.WriteLine(userStory["FormattedID"] + " " + userStory["PlanEstimate"]);
                        storyCount++;
                    }
                    Console.WriteLine(storyCount);
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
