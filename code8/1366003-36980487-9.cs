    static void Main() {
        // don't forget to add interceptor
        DbInterception.Add(new RetryInterceptor());
        MetadataWorkspace workspace = new MetadataWorkspace(
            new string[] {"res://*/"},
            new[] {Assembly.GetExecutingAssembly()});
            // for example       
        var strategy = new FixedInterval("fixed", 10, TimeSpan.FromSeconds(3));
        var manager = new RetryManager(new[] {strategy}, "fixed");
        RetryManager.SetDefault(manager);
        using (var scope = new TransactionScope()) {
            using (var conn = new ReliableSqlConnection("data source=(LocalDb)\\v11.0;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")) {
                // pass Current - we don't need retry logic from ReliableSqlConnection any more
                using (var ctx = new TestDBEntities(new EntityConnection(workspace, conn.Current), false)) {
                    // some sample code I used for testing
                    var code = new Code();
                    code.Name = "some code";
                    ctx.Codes.Add(code);
                    ctx.SaveChanges();
                    scope.Complete();
                }
            }
         }
    }
