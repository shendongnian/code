    protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = "~/Files/Mastering MeteorJS Application Development.pdf";
            String _fileName = "akash";
            string path = MapPath(filename);
            //byte[] bts = System.IO.File.ReadAllBytes(path);
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition:", "attachment;filename=" + _fileName + ".pdf");
            Response.TransmitFile(path);
            //Response.Close();
        }
