    public class CleverName
    {
        public bool IsPriority { get; set; }
        public string Label { get; set; }
        public string Id { get; set; }
        public DateTimeOffset Start { get; set; }
        public string User { get; set; }
        public bool IsValid()
        {
            //Check if Id is valid
        }
        public void TransformAndStore()
        {
            if (this.IsValid()) {
                Label = this.Clean(Label);
                this.Reposit();
            }
        }
        public void Reposit()
        {
        }
    }
