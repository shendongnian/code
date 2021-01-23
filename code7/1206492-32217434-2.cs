    private void DG_OnAutoGeneratingColumns(object sender,DataGridAutoGeneratingColumnEventArgs e)
    System.ComponentModel.PropertyDescriptor propdesc = e.PropertyDescriptor as System.ComponentModel.PropertyDescriptor;
    System.ComponentModel.DataAnnotations.DisplayAttribute displayAttrib =
                pd.Attributes[typeOf(ComponentModel.DataAnnotations.DisplayAttribute)] as System.ComponentModel.DataAnnotations.DisplayAttribute;
    if(displayAttrib!=null)
    {
       e.Column.Header = displayAttrib.Name;
    }
        
