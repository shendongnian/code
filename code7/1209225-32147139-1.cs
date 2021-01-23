    protected void btnEditar_Click(object sender, EventArgs e)
    {
    //Get rowidex of gridview
        int linha = ((System.Web.UI.WebControls.GridViewRow)(((System.Web.UI.Control)(sender)).BindingContainer)).RowIndex;
    //Get the ID in case of editing a item
        ViewState["codigo"] = gdvValores.DataKeys[linha]["id"].ToString();    
    }
