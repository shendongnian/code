<b>For Updating:</b>
<code>
protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
DataSet ds = new DataSet();
ds.ReadXml(Server.MapPath("~/YourXmlFilePath"));
int iXmlRow = Convert.ToInt32(Convert.ToString(ViewState["gridrow"]));
ds.Tables[0].Rows[iXmlRow ]["Name"] = txtFirstName.Text;
ds.Tables[0].Rows[iXmlRow ]["Designation"] = txtLastName.Text;
.....
etc
ds.WriteXml(Server.MapPath("~/YourXMLPath"));
BindGrid();
}
</code>
<b>For Deleting:</b>
<code>
protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
DataSet ds = new DataSet();
ds.ReadXml(Server.MapPath("~/YourXmlFilePath"));
ds.Tables[0].Rows.RemoveAt(e.RowIndex);
ds.WriteXml(Server.MapPath("~/YourXmlFilePath"));
BindGrid();
}
</code>
Hope this help...
