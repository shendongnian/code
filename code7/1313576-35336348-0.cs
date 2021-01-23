    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageViewForm.aspx.cs" Inherits="WebApplication1.ImageViewForm" %>
    
    <!DOCTYPE html>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script src="js/jquery-1.10.1.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
    
                var urlforpdf = document.getElementById("<%=hdnurl.Value%>");
                var data = $("#hdnurl").val();
                if (data != null & data != "" & data != undefined) {
                    $("#pdfurl").css("display", "block");
                    $("#pdfurl").attr("src", data);
                    //alert($("#hdnurl").val());
                }
                else {
                    $("#pdfurl").css("display", "none");
                }
    
            });
    
        </script>
    </head>
    
    
    <body>
        <style>
            .Uplaod {
                margin-left: 479px;
                height: 36px;
                width: 19%;
                background-color: dimgrey;
                color: white;
                font-size: 16px;
                border: 1px solid #333;
            }
        </style>
        <form id="form1" runat="server">
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <br />
            <div style="text-align: center; width: 1024px; margin: 0 auto;">
                <br />
                <label style="font-weight: 700; font-size: 50px;">Tennis Result</label>
                <table width="50%" cellpadding="2" cellspacing="0">
                    <br />
                    <tr>
                        <br />
                        <td style="margin-left: 53%; width: 20%">
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                            </asp:UpdatePanel>
                            <br />
                        </td>
                        <td>
                            <asp:Image ID="imgViewFile" runat="server" Style="height: 500px; border: 10px solid #928F8F; border-radius: 15px; margin: 0 auto" />
                        </td>
    
                    </tr>
                </table>
                <input type="hidden" runat="server" id="hdnurl" name="name" value="" />
                <iframe style="display: none; height: 600px; width: 1000px; border: 10px solid #928F8F; border-radius: 15px;" id="pdfurl"></iframe>
                <br />
            </div>
            <br />
        </form>
    </body>
    </html>
    
    
    **C# CODE**
    
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class ImageUploadForm : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // if (FileUpload1.HasFile)
                //{
                //    FileUpload1.SaveAs(MapPath("~/TEST/" + FileUpload1.FileName));
                //   imgViewFile.ImageUrl = "~/TEST/" + FileUpload1.FileName;
                //}
    
                imgViewFile.Style.Add("display", "none");
            }
            protected void btnUpload_Click(object sender, EventArgs e)
            {
    
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "pdf" };
                string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                bool isValidFile = false;
    
                if (FileUpload1.HasFile)
                {
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isValidFile = true;
                            break;
                        }
                    }
                    if (!isValidFile)
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "Invalid File. Please upload a File with extension " +
                                       string.Join(",", validFileTypes);
                    }
                    else
                    {
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = "File uploaded successfully.";
                    }
                    string dirUrl = "TEST1" + this.Page.User.Identity.Name;
                    string dirPath = Server.MapPath(dirUrl);
                    // string fileName = Path.GetFileNameWithoutExtension(dirPath);
                    // string dirPath = AppDomain.CurrentDomain.BaseDirector
    
    
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string[] filePaths = Directory.GetFiles(dirPath);
                    foreach (string filePath in filePaths)
                        File.Delete(filePath);
                    //var ok = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories)
    
                    //.ToList();
    
                    // save the file to the Specifyed folder  
    
                    string fileUrl = dirUrl + "/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(fileUrl));
                    string exten = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    //Display the Image in the File Upload Control  
    
                    imgViewFile.ImageUrl = fileUrl;
                    imgViewFile.Style.Add("display", "block");
    
                    if (exten == ".pdf")
                    {
                        hdnurl.Value = "../" + fileUrl;
                        //pdfurl.Visible = true;
                        imgViewFile.Style.Add("display", "none");
                    }
                    else
                    {
                        hdnurl.Value = null;
                    }
    
                    //Session["Imagename"] = FileUpload1.FileName;
                }
    
            }
    
        }
    }
