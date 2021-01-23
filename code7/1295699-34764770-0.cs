    public class Data
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Action<Data> OnRemoveCallback { get; set; }
        public void OnRemove()
        {
            OnRemoveCallback(this);
        }
    }
