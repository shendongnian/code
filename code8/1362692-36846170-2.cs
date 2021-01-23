     [Test]
     public async Task TestMyDbCode()
     {
         string dbPath = "path/to/db";
         // do your set up
         CompanyInfo info = await myObject.GetCompanyInfoAsync(dbPath, CancellationToken.None);
         Assert.That(info, Is.NotNull());
         // and finish your assertions.
     }
