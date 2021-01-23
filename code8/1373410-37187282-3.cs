    #region "Declaration"
    private int pageSize = 10;
    SqlConnection con;
    string conquery = "Data Source=.;Initial Catalog=GridviewPagging;User ID=sa;Password = 123";
    #endregion
    #region "Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["startRowIndex"] = 0;
            ViewState["currentPageNumber"] = 0;
        }
    }
    protected void ChangePage(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "First":
                ViewState["currentPageNumber"] = 1;
                ViewState["startRowIndex"] = 0;
                break;
            case "Previous":
                ViewState["currentPageNumber"] = Int32.Parse(lblCurrentPage.Text) - 1;
                ViewState["startRowIndex"] = Convert.ToInt32(ViewState["startRowIndex"]) - pageSize;
                break;
            case "Next":
                ViewState["currentPageNumber"] = Int32.Parse(lblCurrentPage.Text) + 1;
                ViewState["startRowIndex"] = Convert.ToInt32(ViewState["startRowIndex"]) + pageSize;
                break;
            case "Last":
                ViewState["startRowIndex"] = pageSize * (Int32.Parse(lbltotalPages.Text) - 1);
                ViewState["currentPageNumber"] = lbltotalPages.Text;
                break;
        }
        this.fillgridview();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillgridview();
    }
    #endregion
    #region "Methods"
    private DataSet ds(int RowIndex, int Pagesize, string studentname)
    {
        DataSet dataset;
        try
        {
            con = new SqlConnection(conquery);
            SqlCommand cmd = new SqlCommand("SP_GET_STUDENT_DATA", con);
            cmd.Parameters.AddWithValue("@startRowIndex", RowIndex);
            cmd.Parameters.AddWithValue("@pageSize", Pagesize);
            cmd.Parameters.AddWithValue("@studentname", studentname);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = cmd;
                dataset = new DataSet();
                da.Fill(dataset);
            }
            return dataset;
        }
        catch (SqlException ex)
        {
            return dataset = null;
        }
    }
    private void fillgridview()
    {
        DataSet newds = ds(Convert.ToInt32(ViewState["startRowIndex"].ToString()), pageSize, searchbox.Text.Trim());
        if (newds.Tables.Count == 0)
        {
            return;
        }
        else
        {
            btnFirst.Visible = true;
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            lblCurrentPage.Visible = true;
            lbltotalPages.Visible = true;
            lblPageText1.Visible = true;
            lblPageText2.Visible = true;
            ViewState["TotalRows"] = newds.Tables[1].Rows[0][0];
            newds.Tables[1].Rows.Clear();
            if (Convert.ToInt32(ViewState["currentPageNumber"]) == 0)
            {
                ViewState["currentPageNumber"] = 1;
            }
            setPages();
            this.gv.Visible = true;
            this.gv.DataSource = newds.Tables[0];
            this.gv.DataBind();
        }
    }
    private void setPages()
    {
        lbltotalPages.Text = "";
        lblCurrentPage.Text = "";
        try
        {
            lbltotalPages.Text = CalculateTotalPages(Convert.ToDouble(ViewState["TotalRows"])).ToString();
            lblCurrentPage.Text = (ViewState["currentPageNumber"] == null ? "0" : ViewState["currentPageNumber"].ToString());
            if (Int32.Parse(lblCurrentPage.Text) == 0 | Int32.Parse(lbltotalPages.Text) == 0)
            {
                this.btnPrevious.Enabled = false;
                this.btnFirst.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(ViewState["currentPageNumber"]) == 1)
                {
                    this.btnPrevious.Enabled = false;
                    this.btnFirst.Enabled = false;
                    if (int.Parse(lbltotalPages.Text) > 0)
                    {
                        this.btnNext.Enabled = true;
                        this.btnLast.Enabled = true;
                    }
                    else
                    {
                        this.btnNext.Enabled = false;
                        this.btnLast.Enabled = false;
                    }
                }
                else
                {
                    btnPrevious.Enabled = true;
                    btnFirst.Enabled = true;
                }
                if (Convert.ToInt32(ViewState["currentPageNumber"]) == int.Parse(lbltotalPages.Text))
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    private int CalculateTotalPages(double totalrows)
    {
        return Convert.ToInt32(Math.Ceiling(totalrows / pageSize));
    }
    #endregion
