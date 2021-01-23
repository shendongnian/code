    protected void fileUpload()
    {
     if (fileUp.HasFile)
                {
                    fileUp.SaveAs(Server.MapPath("~/PoPDF/" + this.txtCusPo.Text +".PDF"));
                    string imgPrintPo = this.txtCusPo.Text + ".PDF";
                }
    }
