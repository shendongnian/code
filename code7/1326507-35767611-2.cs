      protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) {
                processPayBatch dal = new processPayBatch();
                int batchID = (int)Session["csvbatch"];
                Session["csvbatch"] = null;
                dal.ExportToCSV(batchID);
                string csv = dal.csvFile;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "text/csv";
                HttpContext.Current.Response.Output.Write(csv);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
