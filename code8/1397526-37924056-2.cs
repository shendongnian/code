    public class ContactPerson
    {
            public string FullName { get; set; }
            public string Email { get; set; }
    
            public override string ToString()
            {
                return FullName;
            }
    }
