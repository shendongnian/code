    [TestFixture]
    public class SampleModel
    {
        // stuff
        
        static object [] GetProgramsCases {
            new object[] { new DBContext(), 502 }
        };
        [TestCaseSource("GetProgramsCases")]
        public IQueryable<SomeModel> GetPrograms(DBContext dbContext, int? programId)
        {
            // Assert stuff
        }
    }
