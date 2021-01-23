    //Add using on top of .cs
    using System.Linq;
    
    //In cs class
	public partial class name_of_class : Page
    {
		private List<NewApplicationModels> applicationName = new List<NewApplicationModels>(); 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				 //Do page_load stuff....
				 Session.Remove("name_here");  //reset the Session when first page load
			}
		}
		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
            //Get List from Session
			applicationName = (List<NewApplicationModels>)Session["name_here"];	
			if (applicationName == null)
				applicationName = new List<NewApplicationModels>(); 
			string value = ddlChooseNewApplication.SelectedValue.ToString();
			if (!applicationName.Any(item => item.ApplicationName == value))   
			{
				applicationName.Add(new NewApplicationModels(){ ApplicationName = value});
				Session["name_here"] = applicationName;
				
				ListViewNewApplications.DataSource = applicationName;
				ListViewNewApplications.DataBind();
			}
		}
	}
