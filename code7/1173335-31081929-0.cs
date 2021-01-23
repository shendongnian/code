    public class TestContext : DbContext, IApplicationDbContext
    {
        public TestContext()
        {
            this.ExampleModels= new TestBaseClassDbSet<ExampleModel>();
            //New up the rest of the TestBaseClassDbSet that are need for testing
            //Created an internal method to load the data
            _loadDbSets();
        }
        public DbSet<ExampleModel> ExampleModels{ get; set; }
        //....List of remaining DbSets
        //Local property to see if the save method was called
        public int SaveChangesCount { get; private set; }
        //Override the SaveChanges method for testing
        public override int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
        //...Override more of the DbContext methods (e.g. SaveChangesAsync)
        private void _loadDbSets()
        {
            _loadExampleModels();
        }
        private void _loadExampleModels()
        {
            //ExpectedGlobals is a static class of the expected models 
            //that should be returned for some calls (e.g. GetById)
            this.ExampleModels.Add(ExpectedGlobal.Expected_ExampleModel);
        }
    }
