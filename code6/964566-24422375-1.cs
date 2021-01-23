        protected void AttachFile(object sender, EventArgs e)
        {
            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {
               // your code starts here ..
               if (txtFile.HasFile)
               {
                  //...
               }
               // your code ends here ..
               Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            }
        }
