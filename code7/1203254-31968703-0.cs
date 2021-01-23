    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    
    namespace TestInfo
    {
        class GetTestData
        {
            static void Main(string[] args)
            {
                string serverUrl = "http://tfs2013:8080/tfs/defaultcollection";
                string project = "MyProject";
    
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri(serverUrl));
                ITestManagementService tms = tfs.GetService<ITestManagementService>();
                ITestManagementTeamProject proj = tms.GetTeamProject(project);
    
                // List all Test Plans
                foreach (ITestPlan p in proj.TestPlans.Query("Select * From TestPlan"))
                {
                    Console.WriteLine("------------------------------------------------");
    
                    Console.WriteLine("Test Plan - {0} : {1}", p.Id, p.Name);
                    Console.WriteLine("------------------------------------------------");
    
                    foreach (ITestSuiteBase suite in p.RootSuite.SubSuites)
                    {
                        Console.WriteLine("\tTest Suite: {0}", suite.Title);
    
                        IStaticTestSuite staticSuite = suite as IStaticTestSuite;
                        ITestSuiteEntryCollection suiteentrys = suite.TestCases;
    
                        foreach (ITestSuiteEntry testcase in suiteentrys)
                        {
                            Console.WriteLine("\t\tTest Case - {0} : {1}", testcase.Id, testcase.Title);
                        }
                        Console.WriteLine("");
                      }
    
                    Console.WriteLine("");
                }
            }
        }
    }
    
