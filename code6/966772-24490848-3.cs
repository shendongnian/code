		using xxx.DB;
		using System;
		using System.Collections.Generic;
		using System.Data;
		using System.IO;
		using System.Linq;
		using System.Web;
		using System.Web.UI;
		using System.Web.UI.WebControls;
		namespace xxx_Internal_SQL.PostTree.Reports.FailedLeads
		{
			public partial class Default : System.Web.UI.Page
			{
				private string programName = "Post_Reports_FailedLeads";
				private List<string> lstTransactionSource = new List<string>();
				private List<string> lstTransactionSubSource = new List<string>();
				private List<string> lstTransactionRef = new List<string>();
				private List<string> lstTransactionSubRef = new List<string>();
				private List<string> lstIsTest = new List<string>();
				private string TransactionSource = string.Empty;
				private string TransactionSubSource = string.Empty;
				private string TransactionRef = string.Empty;
				private string TransactionSubRef = string.Empty;
				private string IsTest = string.Empty;
				protected void Page_Load(object sender, EventArgs e)
				{
					try
					{
						if (IsPostBack)
						{
							if (Session["myDataView"] != null)
								BindDataToGV((DataView)Session["myDataView"]);
						}
						else
						{
							FillDDL();
							ViewState["sortOrder"] = "";
							Session["OriginalDT"] = null;
						}
					}
					catch (Exception ex)
					{
						Global.ReportProblem(ex, programName, "Page_Load");
					}
				}
				private void FillTable(string sortExp, string sortDir)
				{
					try
					{
						ClearGV();
						object myData;
						DataTable dtData = GetData();
						Session["OriginalDT"] = dtData;
						if (sortExp != string.Empty)
						{
							DataView myDataView = new DataView();
							myDataView = dtData.AsDataView();
							myDataView.Sort = string.Format("{0} {1}", sortExp, sortDir);
							dtData = myDataView.ToTable();
							Session["OriginalDT"] = dtData;
							Session["myDataView"] = myDataView;
							myData = myDataView;
						}
						BindDataToGV(dtData);
					}
					catch (Exception ex)
					{
						Global.ReportProblem(ex, programName, "FillTable");
					}
				}
				private DataTable GetData()
				{
					return GetData(db, values);
				}
				private void ClearGV()
				{
					gvTransactions.DataSource = null;
					gvTransactions.DataBind();
				}
				private void BindDataToGV(object obj)
				{
					gvTransactions.DataSource = obj;
					gvTransactions.DataBind();
				}
				private DataTable GetData(Database db, SortedList<string, string> values)
				{
					DataTable dt = null;
					try
					{
						if (db.GenericSP("sp_xxx", values, true))
							return db.Output_DT;
					}
					catch (Exception ex)
					{
						Global.ReportProblem(ex, programName, "GetData");
					}
					return dt;
				}
				protected void lnkFindTransactions_Click(object sender, EventArgs e)
				{
					try
					{
						if (ddlAffiliates.SelectedIndex > 0) FillTable("", "");
					}
					catch (Exception ex)
					{
						Global.ReportProblem(ex, programName, "lnkFindTransactions_Click");
					}
				}
				protected void gvTransactions_Sorting(object sender, GridViewSortEventArgs e)
				{
					FillTable(e.SortExpression, sortOrder);
				}
				protected void gvTransactions_PageIndexChanging(object sender, GridViewPageEventArgs e)
				{
					gvTransactions.PageIndex = e.NewPageIndex;
					if (Session["OriginalDT"] != null)
						BindDataToGV((DataTable)Session["OriginalDT"]);
				}
				public string sortOrder
				{
					get
					{
						if (ViewState["sortOrder"].ToString() == "desc")
						{
							ViewState["sortOrder"] = "asc";
						}
						else
						{
							ViewState["sortOrder"] = "desc";
						}
						return ViewState["sortOrder"].ToString();
					}
					set
					{
						ViewState["sortOrder"] = value;
					}
				}
				private void FillDDL()
				{
					if (db.GetRecords("sp_xxx"))
					{
						DataTable dt = db.Output_DT;
						ddlAffiliates.Items.Add(new ListItem("Select...", ""));
						foreach (DataRow dr in dt.Rows)
							ddlAffiliates.Items.Add(new ListItem(dr["name"].ToString(), dr["aid"].ToString()));
					}
				}
			}
		}
