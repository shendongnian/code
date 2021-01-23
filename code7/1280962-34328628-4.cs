    foreach( Control CurrentControl in this.Page.Form.Controls )
    {
      if( CurrentControl is System.Web.UI.WebControls.DropDownList ) {
         var value = ((System.Web.UI.WebControls.DropDownList)CurrentControl).SelectedValue;
         //to do somthing with value
        }
    }
