        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text)) return;            
            
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + txtName.Text);
            string filePath = Server.MapPath(Path.Combine("~/SavedFolder/PDF", txtName.Text));
            Response.TransmitFile(filePath);
            Response.End();
        }
