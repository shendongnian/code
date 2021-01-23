    public class TaskInstanceViewModel
    {
       [DataType(DataType.DateTime)]
       public DateTime DueDate { get; set; }
       public int HowMany { get; set; }
       public IEnumerable<SelectListItem> TaskList { get; set; }
       public virtual ICollection<Task> Task { get; set; }
       //add this property:
       public SelectListItem SelectedItem { get; set; }
    }
