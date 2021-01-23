    void txtControl_TextChanged(object sender, EventArgs e)
    {
        Log = new StringBuilder();
        TextBox txtBox = sender as  TextBox; 
        CompareValidator validateTextBox = new CompareValidator();
        validateTextBox.Operator = ValidationCompareOperator.DataTypeCheck;
        validateTextBox.Type = ValidationDataType.Integer;
        validateTextBox.ControlToValidate = txtBox ;
        string Message = validateTextBoxNumber.ErrorMessage;
     }
