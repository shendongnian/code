       protected void gvDetails_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                Int32 RowIndex = row.RowIndex;
                DataTable dtable = new DataTable();
                dynamic di = new DirectoryInfo(FinalPath+"\\");
                dtable.Columns.Add("DownloadLink", typeof(string));
                dtable.Columns.Add("ActualFileName", typeof(string));
                dtable.Columns.Add("FileName", typeof(string));
                DataRow dr = null;
                foreach (FileInfo fi in di.GetFiles())
                {
                    dr = dtable.NewRow();
                    dr["ActualFileName"] = fi.Name;
                    dr["DownloadLink"] = FinalPath+"\\" + fi.Name;
                    dtable.Rows.Add(dr);
                }
                int i = row.RowIndex;
                string filename = null;
                filename = dtable.Rows[i]["ActualFileName"].ToString();
                string path__1 = (FinalPath + filename);
                string name = dtable.Rows[i]["ActualFileName"] .ToString();
                string last = name.Substring(name.LastIndexOf('.'));
                string ext = last;
                string type = "";
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".html":
                            {
                                type = "text/HTML";
                                break;
                            }
    
                        case ".txt":
                            {
                                type = "text/plain";
                                break;
                            }
    
                        case ".GIF":
                            {
                                type = "image/GIF";
                                break;
                            }
    
                        case ".pdf":
                            {
                                type = "Application/pdf";
                                break;
                            }
    
                        case ".doc":
                            {
                                type = "Application/doc";
                                break;
                            }
                        case ".rtf":
                            {
                                type = "Application/msword";
                                break; 
                            }
    
                        default:
                            {
                                type = "";
                                break; 
                            }
    
                    }
                }
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
                if (!string.IsNullOrEmpty(type))
                {
                    Response.ContentType = type;
                }
                Response.WriteFile(path__1);
                Response.End();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Something Went Wrong!');", true);
                return;
            }
    }
