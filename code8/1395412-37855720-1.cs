    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Test
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Report1.xls");
                Response.ContentType = "application/ms-excel";
    
                const int BUFFER_SIZE = 16 * 1024;
                int bytesRead = BUFFER_SIZE;
                byte[] bytesBuffer = new byte[bytesRead];
                ///
                memoryStream.Position = 0;
                do
                {
                    bytesRead = memoryStream.Read(bytesBuffer, 0, bytesRead);
                    Response.BinaryWrite(bytesBuffer);
                    memoryStream.Flush();
                } while (bytesRead > 0);
            }
        }
    }
