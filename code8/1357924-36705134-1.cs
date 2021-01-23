    class CrudViewModel
    {
        // you should use the full implementation with INPC
        public Record CurrentRecord { get; set; }
        public IList<Record> Records { get; set; }
        public EditMode EditMode { get; set; }
    
        private void CreateNewImpl()
        {
            CurrentRecord = new Record();
            EditMode = EditMode.CreateNew;
        }
        private void EditImpl()
        {
            EditMode = EditMode.Edit;
        }
        private void SaveImpl()
        {
            if (EditMode == EditMode.CreateNew)
            {
                Records.Add(CurrentRecord);
            }
        
            EditMode = EditMode.View;
        }
    }
    
    enum EditMode
    {
        View, CreateNew, Edit
    }
