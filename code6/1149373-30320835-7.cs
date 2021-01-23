public class User
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Range(0, int.MaxValue)]
    public int Age { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
}
