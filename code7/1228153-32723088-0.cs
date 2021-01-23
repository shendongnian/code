        public class CommitteeContextTest : ICommitteeDbContext
        {
            public CommitteeContextTest()
            {
                this.Committees = new TestDbSet<Committee>();
                this.CommitteeMembers = new TestDbSet<CommitteeMember>();
            }
            public Database Database { get; }
            public DbSet<Committee> Committees { get; set; }
            public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        }
    } 
public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
            where TEntity : class
    {
        ObservableCollection<TEntity> _data;
        IQueryable _query;
        public TestDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }
        public override TEntity Add(TEntity item)
        {
            _data.Add(item);
            return item;
        }
        public override TEntity Remove(TEntity item)
        {
            _data.Remove(item);
            return item;
        }
        public override TEntity Attach(TEntity item)
        {
            _data.Add(item);
            return item;
        }
        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }
    }
    [TestClass]
    public class CommitteeServiceTest
    {
        private InterimCommitteeContextTest _interimCommitteeContext;
        private ICommitteeService _service;
        private string _interim;
        [TestInitialize]
        public void SetUp()
        {
            _interimCommitteeContext = new InterimCommitteeContextTest();
            _service = new CommitteeService(_interimCommitteeContext);
            _interim = Settings.Default.DefaultInterimIdentifier;
        }
        [TestCleanup]
        public void Teardown()
        {
            _interimCommitteeContext = null;
            _service = null;
        }
        [TestMethod]
        public void GetCommittee_ProvideInterimCommitteeId_ReturnOneCommittee()
        {
            //Arrange
            AddCommittees();
            //Act and Assert
            var result = _service.GetCommittee(_interim, 1);
            Assert.AreEqual(1, result.CommitteeId); //Passes.  IsActive set to true;
            result = _service.GetCommittee(_interim, 0);
            Assert.IsNull(result); //Fails.  No committeeId = 0;
            result = _service.GetCommittee(_interim, 2);
            Assert.IsNull(result); //Fails.  CommitteeId = 2 is not active.
        }
        [TestMethod]
        public void AddCommittees()
        {
            _interimCommitteeContext.Committees.Add(new Committee() { CommitteeId = 1, InterimIdentifier = _interim, IsActive = true, CommitteeTypeId = 1 });
            _interimCommitteeContext.Committees.Add(new Committee() { CommitteeId = 2, InterimIdentifier = _interim, IsActive = false, CommitteeTypeId = 1 });
            _interimCommitteeContext.Committees.Add(new Committee() { CommitteeId = 3, InterimIdentifier = _interim, IsActive = true, CommitteeTypeId = 1 });
        }
    }
 
