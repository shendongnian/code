    class TaskItem
    {
        private int milisecods = 200;
        DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    
        public TaskItem()
        {
            this.Created = Now;
        }
    
        private DateTime Created;
        public string EntryId { get; set; }
        public bool OutDated
        {
            get
            {
                return this.Created.AddMilliseconds(milisecods) > Now;
            }
        }
    }
    List<TaskItem> TaskItemsList = new List<TaskItem>();
    private void TaskItems_ItemChange(object Item)
    {
        this.TaskItemsList.RemoveAll(x => x.OutDated);
        MailItem element = Item as MailItem;
        if (element != null)
        {
            if (element.FlagStatus == OlFlagStatus.olFlagComplete)
            {
                if (this.TaskItemsList.Any(x => x.EntryId == element.EntryID) == false)
                {
                    this.TaskItemsList.Add(new TaskItem { EntryId = element.EntryID });
                    new WcfClient().ProcesOutlookTask(TaskActionType.Finished);
                }
            }
        }
    }
