    List<string> hdnIdList= new List<string>();
    foreach (DataListItem item in datalist1.Items)
    {
         hdnIdList.Add(((HiddenField)item.FindControl("hfield")).Value);                      
    }
    lbl_note.Text = String.Join("-",hdnIdList);  
