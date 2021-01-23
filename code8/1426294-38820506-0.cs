                DynamicJsonObject sub = restApi.GetSubscription("Workspaces");
    
                Request wRequest = new Request(sub["Workspaces"]);
                wRequest.Limit = 1000;
                QueryResult queryResult = restApi.Query(wRequest);
                int allProjects = 0;
                foreach (var result in queryResult.Results)
                {
                    var workspaceReference = result["_ref"];
                    var workspaceName = result["Name"];
                    Console.WriteLine("Workspace: " + workspaceName);
                    Request projectsRequest = new Request(result["Projects"]);
                    projectsRequest.Fetch = new List<string>()
                    {
                        "Name"
                    };
                    projectsRequest.Limit = 10000; //project requests are made per workspace
                    QueryResult queryProjectResult = restApi.Query(projectsRequest);
                    int projectsPerWorkspace = 0;
                    foreach (var p in queryProjectResult.Results)
                    {
                        allProjects++;
                        projectsPerWorkspace++;
                        Console.WriteLine(projectsPerWorkspace + " Project: " + p["Name"] + " State: " + p["State"]);
                    } 
                }
                Console.WriteLine("Returned " + allProjects + " projects in the subscription");
