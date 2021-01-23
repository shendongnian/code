    public class Account
    {
       public string ac_cd { get; set; }
       public string ac_name { get; set; }
       public Account ac_parent_cd { get; set; }
       public List<Account> ac_children_cd { get; set; }
       public string ac_nature { get; set; }
    }
