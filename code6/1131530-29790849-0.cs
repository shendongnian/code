        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = LoadData(); //Load the data from DB
                EnumerableRowCollection<DataRow> enumerableDt = dt.AsEnumerable();
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    string strID = ((Label)row.FindControl("lblID")).Text;
                    string strGroup = ((Label)row.FindControl("lblGrp")).Text;
                    string strValue = ((TextBox)row.FindControl("txtValue")).Text;
                    DataRow dr = enumerableDt.Where(x => x.Field<string>("ID") == strID).FirstOrDefault(); //Change your condition accordingly 
                    if (dr["Value"].ToString().ToUpper() != strValue.Trim().ToUpper()) //Change your condition here
                    {
                        //Do your updated data logic here
                    }
                    else
                    {
                        //Do your not updated data logic here
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
