    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    [TypeDescriptionProvider(typeof(MetadataTypeTypeDescriptionProvider))]
    public class Person
    {
        [Display(Name = "Id")]
        [Browsable(false)]
        public int? Id { get; set; }
        [Display(Name = "First Name", Description = "First name.", Order = 1)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name", Description = "Last name", Order = 2)]
        public string LastName { get; set; }
        [Display(Name = "Birth Date", Description = "Date of birth.", Order = 4)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Homepage", Description = "Url of homepage.", Order = 5)]
        public string Url { get; set; }
        [Display(Name = "Member", Description = "Is member?", Order = 3)]
        public bool IsMember { get; set; }
    }
