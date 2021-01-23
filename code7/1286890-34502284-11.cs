    public class MakeTransactionModel
    {
       // Your other existing properties here
       public Dictionary<string,decimal> AccountBalances { set; get; }   
       // These 2 properties are for rendering the dropdown.
       public int FromAccountId { set; get; }
       public List<SelectListItem> FromAccounts { set; get; }  
    }
