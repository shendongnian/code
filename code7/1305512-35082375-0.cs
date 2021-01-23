    public class ClassToTest : IInterfaceToTest
    {
        private readonly IBLLogger _logger;
        private readonly IBLDataPopulation _blDataPopulation;
        private readonly IDatabase _database;
        public ClassToTest(IBLLogger logger, IBLDataPopulation blDataPopulation, IDatabase database)
        {
            _logger = logger;
            _blDataPopulation = blDataPopulation;
            _database = database;
        }
        // this cannot be static if you want
        // to unit test the classes depending on this one.
        public Culture UpdatePersonCulture(Guid userId, Culture culture)
        {
            try
            {
                if (userId == Guid.Empty)
                    throw new Exception("User id should not be empty");
                var dataSet = _database.ProvideCultureMappings(userId, culture); 
                                      
                return _blDataPopulation.PopulateCultures(dataSet.Tables[0]).FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw _logger.Log(exception);
            }
        }
    }
