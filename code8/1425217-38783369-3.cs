    //In your aspx file :
    <asp:FileUpload ID="FileUploadControl" runat="server"/>
    <asp:Button runat="server" id="Btn_Upload" text="Upload" onclick="Btn_Upload_Click" />
    //In your aspx.cs file :
    protected void Btn_Upload_Click(object sender, EventArgs e)
    {
         string extension = Path.GetExtension(FileUploadControl.PostedFile.FileName);
         if (extension != ".pdf")
         {
              //Not an PDF
         }
     }
