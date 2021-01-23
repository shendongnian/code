    public interface IDetails
    {
        string Title;
        string Surname;
        string AddressLine1;
        string AddressLine2;
    }
    public partial class Member : IDetails
    {
        //etc
    }
    public partial class Person : IDetails
    {
        //etc
    }
