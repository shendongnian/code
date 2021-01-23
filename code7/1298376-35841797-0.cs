        private void ConvertDataSetToExcelFile(DataSet ds)
        {
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            string FileName = DateTime.Now.Ticks.ToString() + ".xls";
            string FilePath = Server.MapPath("~/upload/excel/");
            GridView2.Visible = true;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            GridView2.RenderControl(htw);
            string renderedGridView = sw.ToString();
            System.IO.File.WriteAllText(FilePath + FileName, renderedGridView);
            GridView2.Visible = false;
            HyperLink1.Visible = true;
            HyperLink1.NavigateUrl = "~/upload/excel/" + FileName;
            HyperLink1.Text = "Download File";
        }
