    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ReportFolder"]))
                {
                    string reportpath = HttpUtility.HtmlDecode(Request.QueryString["ReportFolder"]);
                    int aantalKeys = Request.Params.AllKeys.Length;
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    for (int i = 1; i < aantalKeys; i++)
                    {
                        string value = Request.Params[i];
                        string key = Request.Params.Keys[i];
                        if (key.Contains("_RAP"))
                        {
                            int index = key.IndexOf('_');
                            key = key.Substring(0, index);
                            ReportParameter parameter = new ReportParameter(key, HttpUtility.HtmlDecode(value));
                            parameters.Add(parameter);
                        }
                    }
                    this.RenderReport(reportpath, parameters);
                }
            }
        }
        private void RenderReport(string reportpath, List<ReportParameter> parameters = null)
        {
            string User = [ReportserverUser];
            string Pass = [ReportserverPass];
            string ReportServerUrl = [ResportserverUrl]];
            IReportServerCredentials irsc = new CustomReportCredentials(User, Pass, "");
            Uri uri = new Uri(ReportServerUrl);
            int lastSegment = uri.Segments.Length - 1;
            string page = uri.Segments[lastSegment];
            // EVENTS
            //reportViewer.Load += reportViewer_Load;
            //reportViewer.Unload += reportViewer_Unload;
         
            reportViewer.Visible = true;
            reportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            reportViewer.ServerReport.ReportServerCredentials = irsc;
            reportViewer.ServerReport.ReportServerUrl = new Uri(uri.AbsoluteUri.Replace(page, ""));
            reportViewer.ServerReport.ReportPath = reportpath;
            if (parameters != null && parameters.Count != 0)
            {
                reportViewer.ServerReport.SetParameters(parameters);
                
            }
            reportViewer.ServerReport.Refresh();
        }
        private Dictionary<string, object> GetCurrentParameters()
        {
            var parameterCollection = reportViewer.ServerReport.GetParameters();
            
            var param = new Dictionary<string, object>();
            foreach (var p in parameterCollection)
            {
                var name = p.Name;
                if (p.DataType == ParameterDataType.DateTime)
                {
                    var d = Convert.ToDateTime(p.Values[0]);
                    param[name] = d.ToString("dd-MM-yyyy");
                }
                else
                {
                    var values = p.Values.ToList();
                    param[name] = values;
                }
            }
            return param;
        }
