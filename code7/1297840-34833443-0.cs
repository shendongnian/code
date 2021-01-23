     protected void Button1_Click(object sender, EventArgs e)
    {
       SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MaktubhoConnectionString2"].ConnectionString);
        using (SqlCommand comm = new SqlCommand("DataInserter", conn))
        {
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection = conn;
            SqlParameter employeeparam = new SqlParameter("EmployeeSentIndex", int.Parse(ddlemployee.SelectedItem.Value));
            SqlParameter doctypeparam = new SqlParameter("doctype_ID", int.Parse(ddldoctype.SelectedItem.Value));
            SqlParameter doccharparam = new SqlParameter("docchar_ID", int.Parse(ddldocchar.SelectedItem.Value));
            SqlParameter authorityparam = new SqlParameter("authority", txtauthority.Text);
            SqlParameter subjectparam = new SqlParameter("subject", txtsubject.Text);
            
            DateTime dt = DateTime.Now;
            string todasdate = dt.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
            SqlParameter entrydateparam = new SqlParameter("entrydate", todasdate);
            string Pathname = "UploadImages/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
            SqlParameter imagepathparam = new SqlParameter("image_path",  Pathname);
            SqlParameter loginparam = new SqlParameter("login", "jsomon");
            comm.Parameters.Add(employeeparam);
            comm.Parameters.Add(doctypeparam);
            comm.Parameters.Add(doccharparam);
            comm.Parameters.Add(authorityparam);
            comm.Parameters.Add(subjectparam);
            comm.Parameters.Add(entrydateparam);
            comm.Parameters.Add(imagepathparam);
            comm.Parameters.Add(loginparam);
            comm.Parameters.Add("@forlabel", SqlDbType.VarChar, 100);
            comm.Parameters["@forlabel"].Direction = ParameterDirection.Output;
            FileUpload1.SaveAs(Server.MapPath("~/UploadImages/" + FileUpload1.FileName));
            string ansTo = ddlAnswerTo.SelectedItem.Value;
            SqlParameter answertoparam = new SqlParameter("answertoparam", ansTo);
            string commandText = "update IncomeLetters set IncomeLetters.docState_ID = '2' where income_number = @answertoparam";
            SqlCommand findincomelett = new SqlCommand(commandText, conn);
            findincomelett.Parameters.Add(answertoparam);
                conn.Open();
                findincomelett.ExecuteNonQuery();
                comm.ExecuteNonQuery();
                lblresult.Visible = true;
                Image1.Visible = true;
                lblresult.Text = "Document number:";
                lblnumber.Visible = true;
                lblnumber.Text = (string)comm.Parameters["@forlabel"].Value; ;
                                conn.Close();
   
               
            conn.Close();
            
        }
       
        txtauthority.Text = "";
        txtsubject.Text = "";
           }
