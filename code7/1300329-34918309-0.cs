    public class ApplicationUserRole : IApplicationUserRole<T> where T : Role
    {
        public ApplicationUserRole()
        {
        }
        public User User { get; set; }
        public T Role { get; set; }
    }
