    public class RowViewModel : IEditableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void BeginEdit()
        {
        }
        public void CancelEdit()
        {
        }
        public void EndEdit()
        {
            // this method is called, when user has ended editing
            // TODO: call service layer to update model
        }
    }
