    Range pick1 = worksheet.Range["A5"];
    pick1.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlBetween, "=PrimaryRange");
    Range pick2 = worksheet.Range["A6"];
    
    StringBuilder sb = new StringBuilder();
    sb.Append("Sub InsertCascadingDropDown()" + Environment.NewLine);
    sb.Append("    Range(\"A6\").Select" + Environment.NewLine);
    sb.Append("    With Selection.Validation" + Environment.NewLine);
    sb.Append("        .Delete" + Environment.NewLine);
    sb.Append("        .Add Type:=xlValidateList, AlertStyle:=xlValidAlertStop, Operator:= xlBetween, Formula1:=\"=INDIRECT(A5)\"" + Environment.NewLine);
    sb.Append("        .IgnoreBlank = True" + Environment.NewLine);
    sb.Append("        .InCellDropdown = True" + Environment.NewLine);
    sb.Append("        .ShowInput = True" + Environment.NewLine);
    sb.Append("        .ShowError = True" + Environment.NewLine);
    sb.Append("    End With" + Environment.NewLine);
    sb.Append("End Sub" + Environment.NewLine);
    
    //You need to add a COM reference to Microsoft Visual Basic for Applications Extensibility for this to work
    var xlmodule = workbook.VBProject.VBComponents.Add(Microsoft.Vbe.Interop.vbext_ComponentType.vbext_ct_StdModule); 
    
    xlmodule.CodeModule.AddFromString(sb.ToString()); 
    appl.Run("InsertCascadingDropDown");
