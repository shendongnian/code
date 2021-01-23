        public class HomeController : Controller
        {
            private IUserRepository _repository;
            public HomeController(IUserRepository repository)
            {
                _repository = repository;
            }
            public ActionResult AddNewUser(User newUser)
            {
                _repository.AddUser(newUser);
                return View();
            }
        }
        public interface IUserRepository
        {
            void AddUser(User newUser);
        }
        public class UserRepository : IUserRepository
        {
            private DBContext _context;
            public UserRepository(DBContext context)
            {
                _context = context;
            }
            public void AddUser(User newUser)
            {
                _context.Users.Add(newUser);
            }
        }
        [Test]
        public void ShouldMockRepository()
        {
            // Given
            var repository = new Mock<IUserRepository>();
            var controller = new HomeController(repository.Object);
            // When
            controller.AddNewUser(new User());
            // Then
            repository.Verify(r => r.AddUser(It.IsAny<User>()), Times.Once);
        }
