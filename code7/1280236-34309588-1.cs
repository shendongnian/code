    class CustomGridTextBoxCell : CustomGridCell
    {
        public CustomGridTextBoxCell(string field) 
            : base(field)
        {
        }
    }
    abstract class CustomGridCell : DataGridViewCell
    {
        private string _field;
        public CustomGridCell(string field)
        {
            this._field = field;
        }
        public string field
        {
            get { return this._field; }
        }
    }
