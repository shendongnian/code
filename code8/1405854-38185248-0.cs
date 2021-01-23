    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection("Server=myserver;uid=sa;pwd=nothing;Database=MyDB;");
        SqlCommand command = new SqlCommand("Select top 10 * From Customers", connection);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //Customer _Customer = new Customer();
        DataSet dataset = new DataSet();
        adapter.Fill(dataset, "Customer");
        ReportDocument CustomerReport = new ReportDocument();
        CustomerReport.Load(Server.MapPath("CustomerReport.rpt"));
        CustomerReport.SetDataSource(dataset.Tables["Customer"]);
        CrystalReportViewer1.ReportSource = CustomerReport;
        CrystalReportViewer1.DataBind();
    }
}
