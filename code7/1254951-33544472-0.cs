            Session["slc_filepath"] = "~/Image/images.png";
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(Session["slc_filepath"].ToString());
            downloadAnImage(path);
        }
        private void downloadAnImage(string strImage)
        {
            Response.ContentType = "image/jpg";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + strImage);
            Response.TransmitFile(strImage);
            Response.End();
        }
