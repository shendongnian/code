    public class Email
    {
        string m_stringfrom; // no other fields 
       public static implicit operator string(Email email)
       {
            return email.m_stringfrom;
        }
       public static implicit operator Email(string email)
       {
            return new Email() {
                m_stringfrom = email // only field in email !
            };
       }
    }
    void test()
    {
        Email work_email = "test@domain.com";
        Display(work_email);
    }
    void Display( string toBeDisplayed)
    {
    }
