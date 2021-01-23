    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
     
    public class BlogModel
    {
     [Required]
     [Display(Name = "Title")]
     public string Title { get; set; }
     
     [AllowHtml]
     [Required]
     [Display(Name = "Description")]
     public string Description{ get; set; }
    } 
