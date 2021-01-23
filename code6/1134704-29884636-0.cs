    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Complete { get; set; }
    }
    private List<TaskItem> TaskList = new List<TaskItem>();
    public void deleteSelectedTask(ref ListBox taskListBox)
    {
        var item = (TaskItem) taskListBox.SelectedItem;
        if (item == null) return;
        TaskList.Remove(item);
        taskListBox.DataSource = null;
        taskListBox.DisplayMember = "Title";
        taskListBox.DataSource = TaskList;
    }
