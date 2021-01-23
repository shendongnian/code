    public interface IFirstLastName
    {
        string FirstName { get; }
        string LastName { get; }
    }
    public static class IFirstLastNameExtensions
    {
        public static string FormattedName(this IFirstLastName fln)
        {
            return $"{fln.LastName}, {fln.FirstName}";
        }
    }
    public class StudentDm : EntityBaseDm, IFirstLastName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ProviderDm : IFirstLastName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
Then you could call the FormattedName method on any class which implements IFirstLastName:
