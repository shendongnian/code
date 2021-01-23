     string filename = TextBox1.Text;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "attachment;filename=" + filename);
            Response.TransmitFile(Server.MapPath("~/Your file path/" + filename));
            
            Response.End();
