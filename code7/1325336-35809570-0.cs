    public class AssignPatrolViewModel
    {
        [Display(Name = "Patrol")]
        [Required(ErrorMessage = "Please select a patrol")]
        public int? SelectedPatrol { get; set; }
        public IEnumerable<SelectListItem> PatrolList { get; set; }
        public List<PatrolMemberViewModel> Members { get; set; }
    }
