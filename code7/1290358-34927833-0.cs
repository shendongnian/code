     protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
             {
                 args.IsValid = false;
                 string StaffID = lpartno.Text;
                 SqlConnection conn = new SqlConnection();
    
                 conn.ConnectionString = ConfigurationManager.ConnectionStrings["eFoxNetConnectionString"].ConnectionString;
    
                 SqlDataAdapter da = new SqlDataAdapter("select distinct PartNo from dbo.FTX_SAPPO sp with (nolock) where PartNo=@ID",conn);
                 da.SelectCommand.Parameters.Add("@ID", SqlDbType.VarChar, 120);
                 da.SelectCommand.Parameters["@ID"].Value = StaffID;
                 DataSet ds = new DataSet();
                 da.Fill(ds);
                 if (ds.Tables[0].Rows.Count > 0)
                     args.IsValid = true;
      }
