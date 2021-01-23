    if (Session["UsrNme"] != null)
    {
        if (EditImgFUP.HasFile || EditPersInfologoFileUp.HasFile || EditPesInfoBizImg1FU.HasFile || EditPesInfoBizImg2FU.HasFile || EditPesInfoBizImg3FU.HasFile)
        {
            if ((files.Except(extensions).Count()) <= 0)
            {
                if (....)
                {
                    EditUsrInfoCMD.Connection = EdPersInfoCon;
                    EditUsrInfoCMD.CommandType = CommandType.Text;
                    EditUsrInfoCMD.CommandText = EditUsrInfoSQL;
    
                    EditUsrInfoCMD.Parameters.AddWithValue("@UID", UsrNme);
                    EditUsrInfoCMD.Parameters.AddWithValue("@FN", FNEDTTXTBX.Text);
                }
                // !!! HERE  !!!
            }
            else
            {
                 // !!! HERE  !!!
                EditPersInfoImgFrmtWarnLbl.Text = "Error: The file should have .png or .jpg format only";
                EditPersInfoImgFrmtWarnLbl.ForeColor = System.Drawing.Color.Red;
                EditUsrPan.Visible = true;
            }
    
        }
        else
        {
            string EditUsrInfoSQL = @"Update UserInfo SET  FN=@FN, LN=@LN, Password=@Password, RePass=@RePass, Website=@Website, Post=@Post, Email=@Email, Address=@Address, TeleNum=@TeleNum, Facebook=@Facebook, GooglePlus=@GooglePlus, Twitter=@Twitter Where UID=@UID";
            EditUsrInfoCMD.Connection = EdPersInfoCon;
            EditUsrInfoCMD.CommandType = CommandType.Text;
            EditUsrInfoCMD.CommandText = EditUsrInfoSQL;
        }
