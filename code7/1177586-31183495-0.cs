    public class NewMembershipTypeViewModel
    {
        [Required]
        [Display(Name = "Type")]
        [StringLength(350, ErrorMessage = "Membership Type Name cannot be longer than 350 characters.")]
        public String Type { get; set; }
        [Display(Name = "Description")]
        [StringLength(350, ErrorMessage = "Interest Name cannot be longer than 350 characters.")]
        public String Description { get; set; }
        public int ClubId { get; set; }
        public List<ListMembershipTypeViewModel> TypeList { get; set; }
    }
