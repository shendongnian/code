    ITestPlanCollection plans = testproject.TestPlans.Query("Select * From TestPlan");
                var p = plans.Where(pp => pp.Name == "Plan1").First();
                IStaticTestSuite newSuite = testproject.TestSuites.CreateStatic();
                newSuite.Title = "Acceptance Tests";
                IStaticTestSuite pSuite = p.RootSuite.Entries.Where(s => s.Title == "WindowsFormDemoTest").First().TestSuite as IStaticTestSuite;
                pSuite.Entries.Add(newSuite);
               // p.RootSuite.Entries.Add(newSuite);
                p.Save();
