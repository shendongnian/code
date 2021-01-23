    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Design;
    using System.Diagnostics;
    using System.Linq;
    
	namespace YabbaDabbaDoo
	{
		[TestClass]
		public class MigrationTests
		{
			[TestMethod]
			[TestCategory("RunOnBuild")]
			public void VerifyThereAreNoPendingMigrations()
			{
				// Arrange
				var config = new MyDbMigrationsConfiguration();
				var dbMigrator = new DbMigrator(config);
				// Act
				var pendingMigrations = dbMigrator.GetPendingMigrations().ToList();
				// Visual Assertion
				Trace.WriteLine(pendingMigrations);
				// Assert
				Assert.AreEqual(0, pendingMigrations.Count(), "There are pending EF migrations that need to be ran.");
			}
			[TestMethod]
			[TestCategory("RunOnBuild")]
			public void VerifyDatabaseIsCompatibleWithModel()
			{
				// Arrange
				var context = new MyDbContext();
				// Act
				var isCompatible = context.Database.CompatibleWithModel(false);
				// Visual Assertion
				if (!isCompatible)
				{
					var config = new MyDbMigrationsConfiguration();
					var scaffolder = new MigrationScaffolder(config);
					var pendingMigration = scaffolder.Scaffold("MissingMigration");
					Trace.WriteLine("Missing Migration:");
					Trace.WriteLine("");
					Trace.WriteLine(pendingMigration.UserCode);
				}
				// Assert
				Assert.IsTrue(isCompatible, "The EF model is not compatible with the database. An EF migration needs to be created. See output for sample of missing migration.");
			}
		}
	}
