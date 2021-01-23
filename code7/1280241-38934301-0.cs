    class CustomDataGridColumn : DataGridViewColumn
    {
         this.CellTemplate = new CustomGridTextBoxCell();
    }
    
    class CustomGridTextBoxCell : CustomGridCell
    {
    
    }
    
    class CustomGridCell : DataGridViewCell
    {
        public string fieldA { get; set; }
    
        public CustomGridCell()
        {
    
        }
    }
