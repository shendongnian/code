    public Form2
    {
        TextBox _myTextBox; 
        public Form2()
        { ... }
        
        public DataGridViewCell CurrentCell {get;set;}
        
        protected override void OnLoad()
        {
            Assert(CurrentCell != null);
            _myTextBox = CurrentCell.FormatedValue;
        }
        public SubmitBtn_clicked(...)
        {
            try
            {
               var cellValue = CurrentCell.ParseFormattedValue(_myTextBox.Text,  
                         CurrentCell.Style, (TypeConverter)null, (TypeConverter)null);
               CurrentCell.Value = cellValue;
            }
            catch(FormatException)
            {/*user entered value that cant be parsed*/ }
            catch(ArgumentException)
            {/*_myTextBox.Text was null or cell's FormattedValueType is not string*/}
        }
    }
