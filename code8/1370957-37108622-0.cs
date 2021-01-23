     protected void btn_ViewSlip_Click(object sender, EventArgs e)
        {
            dt_Payslip = mm_salary.GetPayslipData(DDL_Year.SelectedValue.ToString(), DDL_Month.SelectedValue.ToString(), Session["empcd"].ToString());
            if (dt_Payslip.Rows.Count > 0)
            {
                dt_CurrPay = emp_coprofile.GetCurrExp(Session["empcd"].ToString(), DDL_Month.SelectedValue.ToString(), DDL_Year.SelectedValue.ToString());
                GenerateDisclaimerPDF();
                string url = FilesPath.Path_SaveFile + Session["empcd"].ToString() + " - Payslip.pdf";
                System.IO.FileInfo file = new System.IO.FileInfo(url);
                if (file.Exists)
                {
                    //WebClient client = new WebClient();
                    //Byte[] buffer = client.DownloadData(url);
                    //Response.ContentType = "application/pdf";
                    //Response.AddHeader("content-length", buffer.Length.ToString());
                    //Response.BinaryWrite(buffer);
                   // Response.Clear();
                    WebClient client = new WebClient();
                    Byte[] buffer = client.DownloadData(url);
                    Response.AddHeader("content-disposition", "attachment; filename=" + Session["empcd"].ToString() + " - Payslip.pdf");
                    Response.AddHeader("content-length", buffer.Length.ToString());  
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(buffer);
                }
            }
            else
            {
                msg = "Pay slip for "+DDL_Month.SelectedValue.ToString()+"-"+DDL_Year.SelectedValue+" does not exist";
            }
        }
