    foreach (var row in group)
    {
        sbodyMail += "<tr>" +
            "<td style='width: 100px; height: 14px;background-color:" + strcolorDet + "'>" + row["userName"].ToString() + " </td> " +
            "<td style='width: 100px; height: 14px;background-color:" + strcolorDet + "'>" + row["Doc_Type"].ToString() + " </td> " +
            "<td style='width: 100px; height: 14px;background-color:" + strcolorDet + "'>" + row["CountofDocNo"].ToString() + " </td> " +
            "</tr>";
    
            sbodyMail += "</table><br>" + //close of header
            "<b>THIS IS A SYSTEM GENERATED MAIL. PLEASE DO NOT REPLY </b>";
            string strExp = "";
            string startupPath = "";
            List<string> ls_attach1 = new List<string>();
            MailMessage mail = new MailMessage();
            startupPath = Environment.CurrentDirectory;
            strExp = "RAName = '" + group.Key + "'";
            DataTable dtNew = ds.Tables[1].Select(strExp).CopyToDataTable();
            DataSet dsNew = new DataSet();
            dsNew.Tables.Add(dtNew);
    
            ExcelLibrary.DataSetHelper.CreateWorkbook(startupPath +     "\\Attachment\\Reminder_Sheet.xls", dsNew);
            ls_attach1.Add(startupPath + "\\Attachment\\Reminder_Sheet.xls");
            foreach (var attach in ls_attach1)
              {
                mail.Attachments.Add(new Attachment(attach));
              }
    
            ce.SendEmail(row["userName"].ToString(), "", "", "Information on documents for processing", sbodyMail, "AUTOSQL", "Powersoft", ls_attach1, "ConnectionString");
    }
