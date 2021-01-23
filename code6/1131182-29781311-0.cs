     <asp:FileUpload ID="FileUpload1" runat="server" />
     <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
     using System.IO;
     using System.Collections.Generic;
     protected void Upload(object sender, EventArgs e)
     {
        if (FileUpload1.HasFile)
        {
        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
        Response.Redirect(Request.Url.AbsoluteUri);
       }
     }
