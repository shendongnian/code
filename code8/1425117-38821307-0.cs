    if (Request.QueryString["ProcessName"].ToString().Equals("Ebill"))
                    {
                        using (SqlCommand cmd = new SqlCommand("AR_Ebill_claim", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            string compcode = null;
                            DateTime dateFrom = DateTime.Now;
                            DateTime dateTo = DateTime.Now;
                            string episType = null;
                            string debtorCode = null;
                            if (Request.QueryString["compcode"] != null)
                            {
                                if (string.IsNullOrEmpty(Convert.ToString(Request.QueryString["compcode"])))
                                {
                                    compcode = null;
                                }
                                else
                                {
                                    compcode = Convert.ToString(Request.QueryString["compcode"]);
                                }
                            }
                            if (Request.QueryString["dateFrom"] != null)
                            {
                                DateTime dtFrom = DateTime.Parse(Request.QueryString["dateFrom"]);
                                dtFrom.ToString("dd-MMM-yyyy");
                                if (dtFrom == null)
                                {
                                    dateFrom = DateTime.Now;
                                }
                                else
                                {
                                    dateFrom = dtFrom;
                                }
                            }
                            if (Request.QueryString["dateTo"] != null)
                            {
                                DateTime dtTo = DateTime.Parse(Request.QueryString["dateTo"]);
                                dtTo.ToString("dd-MMM-yyyy");
                                if (dtTo == null)
                                {
                                    dateTo = DateTime.Now;
                                }
                                else
                                {
                                    dateTo = dtTo;
                                }
                            }
                            if (Request.QueryString["episType"] != null)
                            {
                                if (string.IsNullOrEmpty(Convert.ToString(Request.QueryString["episType"])))
                                {
                                    episType = null;
                                }
                                else
                                {
                                    episType = Convert.ToString(Request.QueryString["episType"]);
                                }
                            }
                            if (Request.QueryString["debtorCode"] != null)
                            {
                                if (string.IsNullOrEmpty(Convert.ToString(Request.QueryString["debtorCode"])))
                                {
                                    debtorCode = null;
                                }
                                else
                                {
                                    debtorCode = Convert.ToString(Request.QueryString["debtorCode"]);
                                }
                            }
                            cmd.Parameters.Add("@compcode", SqlDbType.VarChar, 100);
                            cmd.Parameters["@compcode"].Value = compcode;
                            cmd.Parameters.Add("@dateFrom", SqlDbType.SmallDateTime);
                            cmd.Parameters["@dateFrom"].Value = dateFrom;
                            cmd.Parameters.Add("@dateTo", SqlDbType.SmallDateTime);
                            cmd.Parameters["@dateTo"].Value = dateTo;
                            cmd.Parameters.Add("@episType", SqlDbType.VarChar, 40);
                            cmd.Parameters["@episType"].Value = episType;
                            cmd.Parameters.Add("@debtorCode", SqlDbType.VarChar, 100);
                            cmd.Parameters["@debtorCode"].Value = debtorCode;
                            con.Open();
                            //cmd.ExecuteNonQuery();
                            //gdBill.EmptyDataText = "No Records Found";
                            //gdBill.DataSource = cmd.ExecuteReader();
                            //gdBill.DataBind(); 
                            string outputFilePath = Server.MapPath("~/Documents/EClaim.txt");
                            if (File.Exists("~/Documents/EClaim.txt"))
                            {
                                File.Delete("~/Documents/EClaim.txt");
                            }
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            int[] maxLengths = new int[dt.Columns.Count];
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                maxLengths[i] = dt.Columns[i].ColumnName.Length;
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (!row.IsNull(i))
                                    {
                                        int length = row[i].ToString().Length;
                                        if (length > maxLengths[i])
                                        {
                                            maxLengths[i] = length;
                                        }
                                    }
                                }
                            }
                            using (StreamWriter sw = new StreamWriter(outputFilePath, false))
                            {
                                //for (int i = 0; i < dt.Columns.Count; i++)
                                //{
                                //    sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                                //}
                                sw.WriteLine();
                                foreach (DataRow row in dt.Rows)
                                {
                                    for (int i = 0; i < dt.Columns.Count; i++)
                                    {
                                        if (!row.IsNull(i))
                                        {
                                            sw.Write(row[i].ToString().PadRight(maxLengths[i] + 1));
                                        }
                                        else
                                        {
                                            sw.Write(new string(' ', maxLengths[i] + 1));
                                        }
                                    }
                                    sw.WriteLine();
                                }
                                sw.Close();
                            }
                            //string filePath = "~/Documents/EBilling.txt";
                            //Response.ContentType = "application/text";
                            //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                            //Response.TransmitFile(Server.MapPath(filePath));
                            ////Response.End();                           
                        }
