    public class MyManager : IMyManager {
        private IMyRespository myRepository;
        public MyManager(IMyRespository myRepository) {
            this.myRepository = myRepository;
        }
        public async Task<CustomerResponseObject> TestIdentity(string username) {
            var role = await myRepository.GetRole(username);
            var result = new CustomerResponseObject {
                Role = role
            };
            return result;
        }
    }
