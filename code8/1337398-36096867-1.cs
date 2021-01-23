    [TestClass]
    public class DynamicResultsTests {
        List<UserModel> testUsers = new List<UserModel>();
        string[] names = new[] { "John Doe", "Jane Doe", "Jack Sprat", "John Smith", "Mary Jane" };
        [TestInitialize]
        public void Init() {
            testUsers = names.Select(n => {
                var tokens = n.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                return new UserModel { firstName = tokens[0], lastName = tokens[1] };
            }).ToList();
        }
        [TestMethod]
        public void Test_ShouldDynamicallyReturnResultsBasedOnParameterValue() {
            //Arrange
            string parameterValue = "john";
            Func<string, UserModel, bool> predicate = (s, u) => string
                    .Join(" ", u.firstName, u.lastName)
                    .IndexOf(s, StringComparison.InvariantCultureIgnoreCase) > -1;
            Expression<Func<string, bool>> parameterMatch = s => 
                this.testUsers.Any(u => predicate(s, u));
            Func<string, List<UserModel>> valueFunction = s =>
                this.testUsers.Where(u => predicate(s, u)).ToList();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(r => r.GetAllUsersByName(It.Is<string>(parameterMatch)))
                .Returns<string>(valueFunction);
            var repository = mockUserRepository.Object;
            //Act
            var users = repository.GetAllUsersByName(parameterValue);
            //Assert (There should be 2 results that match john)
            users.Should().NotBeNull();
            users.Should().NotBeEmpty();
            users.Count().Should().Be(2);
        }
        public interface IUserRepository {
            List<UserModel> GetAllUsersByName(string name);
        }
        public class UserModel {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    }
