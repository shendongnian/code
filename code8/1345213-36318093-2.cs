    using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;
    public class ResetPasswordViewModel
    {
       [DataType(DataType.Password)]   
       [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
       public string Password { set;get;}
       //Other properties as needed
    }
