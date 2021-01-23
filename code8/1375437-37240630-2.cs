    //Add using on top of .cs
    using System.Linq;
    
    //In cs class
	public partial class _Default : Page
    {
		private static List<NewApplicationModels> applicationName = new List<NewApplicationModels>(); 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				 //Do page_load stuff....
				 applicationName = new List<NewApplicationModels>();  //reset the List when page is loaded 
			}
		}
		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string value = ddlChooseNewApplication.SelectedValue.ToString();
			if (!applicationName.Any(item => item.ApplicationName == value))   //Check if value already added then do nothing
			{
				applicationName.Add(new NewApplicationModels(){ ApplicationName = value});
				ListViewNewApplications.DataSource = applicationName;
				ListViewNewApplications.DataBind();
			}
		}
	}
