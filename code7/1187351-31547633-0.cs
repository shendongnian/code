    DataTable dt1 = DA.Get_Boards_Inspected(startDate, endDate, location);
                    DataTable dt2 = DA2.Get_Boards_With_Issue(startDate, endDate, location);
                    
                    DataColumn newCol = new DataColumn("dcount", typeof(System.Object));
                    newCol.AllowDBNull = true;
                    dt1.Columns.Add(newCol);
                    foreach(DataRow r in dt1.Rows)
                    {
                        object wo = (r["board_wo_number"]).ToString();
                        object tp = (r["top_or_bottom"]).ToString();
                        
                        if (tp == "")
                        {
                            foreach (DataRow r1 in dt2.Select("board_wo_number = '" + wo + "'"))
                            {
                                if (r1["count"] == DBNull.Value)
                                    r["dcount"] = 0;
                                else
                                    r["dcount"] = (r1["count"]);
                            }
                        }
                        else
                        {
                            foreach (DataRow r1 in dt2.Select("board_wo_number = '" + wo + "' and top_or_bottom = '" + tp + "'"))
                            {
                                if (r1["count"] == DBNull.Value)
                                    r["dcount"] = 0;
                                else
                                    r["dcount"] = (r1["count"]);
                            }
                        }
                    }
                    foreach (DataRow dr in dt1.Rows)
                    {
                        object tpn = (dr["top_or_bottom"]);
                        object ct = (dr["count"]).ToString();
                        object wo = (dr["board_wo_number"]).ToString();
                        object ct2 = (dr["dcount"]).ToString();
                        if (tpn == DBNull.Value)
                        {
                            chart1.Series["Boards Inspected"].Points.AddXY(wo, ct);
                            chart1.Series["Boards With Issue"].Points.AddXY(wo, ct2);
                        }
                        else
                        {
                            chart1.Series["Boards Inspected"].Points.AddXY(wo + " - " + tpn, ct);
                            chart1.Series["Boards With Issue"].Points.AddXY(wo + " - " + tpn, ct2);
                        }
                    }      
