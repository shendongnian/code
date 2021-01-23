    public interface IMyManager {
        Task<CustomerResponseObject> TestIdentity(string username);
    }
    public interface IMyRespository {
        Task<RoleObject> GetRole(string username);
    }
    public class RoleObject {
        public string Name { get; set; }
    }
    public class CustomerResponseObject {
        public RoleObject Role { get; set; }
    }
