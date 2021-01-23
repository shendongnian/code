       [TestMethod]
        public async Task GetVendors_ByRegionId_ReturnFilteredVendors()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Server=server12345;Database=DB789;Trusted_Connection=True;MultipleActiveResultSets=true");
            var ctx = new ApplicationDbContext(optionsBuilder.Options);
            ILoggerFactory logFac = new LoggerFactory();
            ILogger<VendorRepository> loggerRepository = new Logger<VendorRepository>(logFac);
            IVendorRepository vendRepo = new VendorRepository(ctx, loggerRepository);
            // Act
            Task<List<Vendor>> resultTask = vendRepo.GetVendors(1);
            IList<Vendor> vendorList = await resultTask;
            // Assert
            Assert.IsNotNull(vendorList);
            Assert.IsTrue(vendorList.Count > 10);
        }
