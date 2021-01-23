    public partial class DynamicPage : System.Web.UI.Page
    {
    	private int NumberOfDynamicControls
    	{
    		get
    		{
    			var numberOfDynamicControls = ViewState["__dynamicUCCount"];
    			if (numberOfDynamicControls != null)
    			{
    				return (int)numberOfDynamicControls;
    			}
    			return 0;
    		}
    		set
    		{
    			ViewState["__dynamicUCCount"] = value;
    		}
    	}
    	private List<DynamicUC> _dynamicUCList;
    
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		RestoreDynamicUC();
    	}
    
    	protected void btnAddUC_Click(object sender, EventArgs e)
    	{
    		CreateDyanamicUC(NumberOfDynamicControls);
    		NumberOfDynamicControls++;
    	}
    
    	private void RestoreDynamicUC()
    	{
    		if (NumberOfDynamicControls == 0)
    			return;
    		for (int i = 0; i < NumberOfDynamicControls; i++)
    		{
    			CreateDyanamicUC(i);
    		}
    	}
    
    	private void CreateDyanamicUC(int dataIndex)
    	{
    		if (_dynamicUCList == null)
    		{
    			_dynamicUCList = new List<DynamicUC>();
    		}
    		var dynamicUC = LoadControl("DynamicUC.ascx") as DynamicUC;
    		dynamicUC.PopulateData("Data " + dataIndex);
    		pnlDynamicUCPanel.Controls.Add(dynamicUC);
    		_dynamicUCList.Add(dynamicUC);
    	}
    
    	protected void btnGetUCValues_Click(object sender, EventArgs e)
    	{
    		var valuesText = "";
    		if (_dynamicUCList != null)
    		{
    			valuesText = string.Join(", ", _dynamicUCList.Select(duc => duc.GetData()));
    		}
    		lblUCValues.Text = "UC Values: " + valuesText;
    	}
    }
