    <asp:TemplateField HeaderText="SFTP_KNOWNHOST_KEY_ID *"
                            SortExpression="SFTP">
        // Stuff goes here
    </asp:TemplateField>
    <asp:TemplateField HeaderText="REPRESENTATION_TYPE
                            SortExpression="FTP_FIELD">
        // Stuff goes here
    </asp:TemplateField>
    <asp:TemplateField HeaderText="FTPS_CACERTIFICATE_ID
                            SortExpression="FTPS">
        // Stuff goes here
    </asp:TemplateField>
    private static bool showFTP, showSFTP, showFTPS;
    protected void FTP_MODEBtns_SelectedIndexChanged(object sender, EventArgs e)
    {
        string mode = FTP_MODEBtns.SelectedValue;
        if (mode == "FTP")
            {
                showFTP = true;
                showSFTP = false;
                showFTPS = false;
            }
            else
            {
                showFTP = false;
                showSFTP = true;
                showFTPS = false;
            }
        SetVisibility();
    }
    static internal void SetVisibility()
        {
            foreach (DataControlField f in FTPView.Fields)
            {
                string htext = f.SortExpression;  
                if (htext.Contains("SFTP"))
                    f.Visible = showSFTP;
                else if (htext.Contains("FTP_FIELD"))
                    f.Visible = showFTP;
                else if (htext.Contains("FTPS"))
                    f.Visible = showFTPS;                
            }
        }
