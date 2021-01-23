    using System.ComponentModel.DataAnnotations.Schema;
    public class Customer
    {
        ..... {get; set;}
        ..... {get; set;}
        //String Length = 450 will avoid error if string is set to max
        [StringLength(450)]
        [Index(IsUnique=true)]
        public string Email{get;set;}
    }
