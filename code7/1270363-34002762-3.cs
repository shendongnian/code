    [SetUpFixture]
	public class TestSetup
	{
		[SetUp]
		public void SetUpTests()
        {
	        var projectPath = @"C:SomeDirectory";
            var project = new Project( projectPath );
	        project.Build();
	        ProjectCollection.GlobalProjectCollection.UnloadProject( project );
            
            var dacPac = new DacPacUtility();
            var connString = "Data Source=(localdb)\ProjectsV12;Initial Catalog=Tests;Integrated Security=True";
            var dacPacPath = projectPath + "..\bin\projectName.dacpac";
            dacPac.DeployDacPac(connString, dacPacPath, "Tests");
         }
         [TearDown]
         public void TearDownTests()
         {
           // TODO: delete db or run other cleanup scripts
         }
     }
