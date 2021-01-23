    public interface ITestUser
    {
        int id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string FormattedName();
    }
    static class ITestUserHelpers
    {
        public static string FormattedNameDefault(this ITestUser user)
        {
            return user.lastName + ", " + user.firstName;
        }
    }
    public class TestUser : ITestUser
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string FormattedName()
        {
            return this.FormattedNameDefault();
        }
    }
