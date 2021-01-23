    public class Customer { public string Email { get; set; } }
    
    static void Main(string[] args)
    {
        Customer lc = new Customer();
        Customer rc = new Customer();
        rc.Email = "abc";
        bool modified = SetIfModified(x => x.Email, lc, rc);
    }
