      protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Sub"] == "Doc")
            {
                string _loc = Request.QueryString["Loc"];
                string _fecha = Request.QueryString["Fecha"];
                string _Ap_Id = Request.QueryString["AP"];
                string _TT_Id = Request.QueryString["TT_Id"];
                int loc_id = 0, TT_id = 0, Ap_Id = 0;
                CultureInfo provider = new CultureInfo("en-US");
                DateTime Fecha = DateTime.Now;
                if (!string.IsNullOrEmpty(_loc))
                    loc_id = Convert.ToInt32(_loc);
                if (!string.IsNullOrEmpty(_fecha))
                    Fecha = DateTime.ParseExact(_fecha,"dd/MMM/yyyy",provider);
                if (!string.IsNullOrEmpty(_Ap_Id))
                    Ap_Id = Convert.ToInt32(_Ap_Id);
                if (!string.IsNullOrEmpty(_TT_Id))
                    TT_id = Convert.ToInt32(_TT_Id);
                if (TT_id == 14 || TT_id == 15 || TT_id == 21)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    paramList.Add(new ReportParameter("LocId", _loc));
                    paramList.Add(new ReportParameter("Fecha", Fecha.ToShortDateString()));
                    paramList.Add(new ReportParameter("TT_Id", _TT_Id));
                    paramList.Add(new ReportParameter("TT_Doc", _Ap_Id));
                    ReportDataSource data = new ReportDataSource("ARACLDS", new InventarioRptCs().Selecciona_Saldos_Articulo_Doc(loc_id, Fecha, TT_id, Ap_Id).ToList());
                    RVSubNav.LocalReport.ReportPath = "Rdlcs\\ReporteKardexDoc.rdlc";
                    RVSubNav.Visible = true;
                    RVSubNav.LocalReport.SetParameters(paramList);
                    RVSubNav.LocalReport.DataSources.Clear();
                    RVSubNav.LocalReport.DataSources.Add(data);
                    RVSubNav.LocalReport.Refresh();
                }
            }
           
        }
    }
