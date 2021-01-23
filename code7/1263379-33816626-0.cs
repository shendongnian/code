     public static void ExportGrid(TBL_CONDORDataTable dt, string filename)
        {
            try
            {
                HttpResponse response = HttpContext.Current.Response;
                // first let's clean up the response.object
                response.Clear();
                response.Charset = "";
                // set the response mime type for excel
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                // create a string writer
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        // instantiate a datagrid
                        DataGrid dg = new DataGrid();
                        dg.DataSource = dt;
                        dg.DataBind();
                        dg.RenderControl(htw);
                        response.Write(sw.ToString());
                        response.End();
                    }
                }
            }
            catch (Exception ex)
            { string msg = ex.Message.ToString(); }
        }
    }
