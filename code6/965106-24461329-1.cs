    static void Main(string[] args)
            {
                int storyCount = 0;
                int taskCount = 0;
                RallyRestApi restApi;
                restApi = new RallyRestApi("apiuser@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                String workspaceRef = "/workspace/1234";     //replace this OID with an OID of your workspace
    
                Request sRequest = new Request("HierarchicalRequirement");
                sRequest.Workspace = workspaceRef;
                sRequest.Fetch = new List<string>() { "FormattedID", "Name", "Tasks", "Release", "Project", "Owner" };
                sRequest.Query = new Query("Release.Name", Query.Operator.Equals, "r1").And(new Query("Owner", Query.Operator.Equals, "user@co.com"));
                QueryResult queryResults = restApi.Query(sRequest);
    
                foreach (var s in queryResults.Results)
                {
                    Console.WriteLine("FormattedID: " + s["FormattedID"] + " Name: " + s["Name"] + " Release: " + s["Release"]._refObjectName + " Project: " + s["Project"]._refObjectName + " Owner: " + s["Owner"]._refObjectName);
                    storyCount++;
                    Request tasksRequest = new Request(s["Tasks"]);
                    QueryResult queryTaskResult = restApi.Query(tasksRequest);
                    foreach (var t in queryTaskResult.Results)
                    {
                        Console.WriteLine("Task: " + t["FormattedID"] + " State: " + t["State"]);
                        taskCount++;
                    }
                }
                Console.WriteLine(storyCount + " stories, "+  taskCount + " tasks ");
            }
