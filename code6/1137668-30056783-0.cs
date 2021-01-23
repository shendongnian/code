	protected void ApplicationList_SelectedIndexChanged(object sender, EventArgs e)
	{
		ASPxComboBox cb = (ASPxComboBox)sender;
		ASPxGridCustomers.FilterEnabled = true;
		ASPxGridCustomers.FilterExpression = "( applicationid = " + cb.SelectedItem.Value + ")";
		Session["cbSelectedValue"] = cb.SelectedItem.Value;
		ASPxButtonAll.ClientEnabled = true;
	}
	protected void UploadControl_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
	{
		try
		{
			FileInfo fileinfo = new FileInfo(e.UploadedFile.FileName);
			string s = "";
			try
			{
				s = Session["cbSelectedValue"].ToString();
			}
			catch (Exception ex) 
			{
				throw new Exception(ex.Message);
			}
			byte[] attachmentfile = GetBytes(fileinfo.Name);
			putDocumentToDB(selectedApp, attachmentfile);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
    // in case your combobox has a selected value on page load
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			Session["cbSelectedValue"] = cb.SelectedItem.Value;
		}
	}
