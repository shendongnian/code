     protected void Page_Load(object sender, EventArgs e)
     {
                if (!Page.IsPostBack)
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                }
     }
 
     protected void Page_PreRender(object sender, EventArgs e)
     {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];      
     }
     protected void btn_AddEdu_Click(object sender, EventArgs e)
     {
       if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
        {
        hfTab.Value = "edu";
         if (ValidateAddEdu())
         {
            emp_edu.InsertEdu(Session["empcd"].ToString(), ddl_degree.SelectedValue.ToString(), txt_eduterms.Text, ddl_institute.SelectedValue.ToString(), txt_edupassyear.Text, txt_edugrade.Text, ddl_sponsor.SelectedValue.ToString());
            int imagefilelength = fileupload_edu.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelength];
            HttpPostedFile image = fileupload_edu.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelength);
            edu_attach.InsertEduAttachment(Session["empcd"].ToString(),ddl_degree.SelectedValue.ToString(),imgarray);
            lbl_eduerr.Text = "Added";
           //Add this line
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            lbl_eduerr.ForeColor = System.Drawing.Color.Green;
            BindEduGrid();
    
         }
        }
    }
