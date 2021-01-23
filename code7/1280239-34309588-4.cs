    abstract class CustomGridCell : DataGridViewCell
    {
        public string field { get; set; };
        public CustomGridCell(string field)
        {
            this.field = field;
        }
    }
