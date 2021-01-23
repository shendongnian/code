        grdEmail.RootTable.Columns("receive_email").ColumnType = ColumnType.CheckBox
        grdEmail.RootTable.Columns("receive_email").EditType = EditType.CheckBox
        grdEmail.RootTable.Columns("receive_email").CheckBoxTrueValue = "Yes"
        grdEmail.RootTable.Columns("receive_email").CheckBoxFalseValue = "No"
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grdEmail.RootTable.Columns("receive_email"), ConditionOperator.Equal, "Yes")
        fc.FormatStyle.BackColor = Color.LightBlue
        grdEmail.RootTable.FormatConditions.Add(fc)
