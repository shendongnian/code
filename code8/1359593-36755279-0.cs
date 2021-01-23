    protected void btn_SaveToFile_Click(object sender, EventArgs e) {
        string path = Server.MapPath("~/Sheets/");
        if (!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
        }
        string fname=DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".xls";
        try {
            using (StringWriter sw = new StringWriter()) {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw)) {
                    StreamWriter writer = File.AppendText(path + fname);
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename="+fname);
                    Response.TransmitFile(path+fname));
                    Response.End();
                }
            }
        }
        catch (Exception ex){
            Debug.WriteLine("Error saving to file: " + ex.Message);
        }
    }
