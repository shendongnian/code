    class NumericEditControl : NumericTextBox, IDataGridViewEditingControl
    {
        //Old code here
        protected override void OnTextChanged(EventArgs e)
        {
            if (dataGridView != null)
            {
                valueChanged = true;
                
                this.dataGridView.NotifyCurrentCellDirty(true);
                base.OnTextChanged(e);
            }
        }
    }
