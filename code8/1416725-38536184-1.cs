    public class ItemSelectionNotification : Confirmation
    {
        public ItemSelectionNotification() { }
        public ItemSelectionNotification(object payload)
        {
            Payload = payload;
        }
        public object SelectedItem { get; set; }
        public object Payload { get; } = null;
    }
