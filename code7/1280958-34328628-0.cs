foreach( Control CurrentControl in this.Page.Form.Controls )
{
  if( typeof( CurrentControl ) is System.Web.UI.WebControls.DropDownList )
{
 var value = ((System.Web.UI.WebControls.DropDownList)Control).SelectedValue;
//to do width value
}
}
