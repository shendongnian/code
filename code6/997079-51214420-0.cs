     public class Account : IdentityUser
     {
        [ScaffoldColumn(false)]
        public override string Id { get; set; } 
        //Other properties ....
     }
