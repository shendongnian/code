    protected void submit_Click(object sender, EventArgs e)
    {
    
        missionBO objMissionBo = new missionBO();
        if (HiddenField1.Value == "")
        {
            objMissionBo.heading = TextBox1.Text.Trim();
            if (insertimage.HasFile)
            {
                //int length = insertimage.PostedFile.ContentLength;
                string filename = insertimage.FileName;
                insertimage.PostedFile.SaveAs(Server.MapPath(@"~\Upload\" + filename.Trim()));
                string path = filename.Trim();
                //byte[] imgbyte = new byte[length];
                //HttpPostedFile img = insertimage.PostedFile;
                //img.InputStream.Read(imgbyte, 0, length);
                objMissionBo.image = path;
    
            }
            objMissionBo.description = TextBox2.Text.Trim();
            missionvissionBL objMissionBL = new missionvissionBL();
            string action = "insert";
            int result = objMissionBL.insertMissionData(objMissionBo, action);
            if (result == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "prompt", "alert('Data inserted successfully.'); storeinput('"+result +"');", true);
                clearAll();
                Response.Redirect("missionvision.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "prompt", "alert('Data could not inserted successfully.'); storeinput('"+result +"');", true);
            }
        }
    
    <script>
        function storeinput(value) {
            console.log('value',value);
            document.getElementById("<%=hidValue.ClientID%>").value = value;
        }
    </script>
