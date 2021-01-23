     public static bool IsValidEmail(string emailaddress)
        {
               return new EmailAddressAttribute().IsValid(emailaddress);
        }
    // using System.ComponentModel.DataAnnotations;
