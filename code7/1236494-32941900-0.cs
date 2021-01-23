    namespace eTransport
    {
        public partial class Appform : System.Web.UI.Page
        {
    private bool isNotDup 
    {
       set { ViewState["isNotDup "] = value; }
       get 
       {
          if (ViewState["isNotDup "] == null)
             return true;
          return (bool )ViewState["isNotDup "];
       }
    }
    private bool avail_bus 
    {
       set { ViewState["avail_bus"] = value; }
       get 
       {
          if (ViewState["avail_bus"] == null)
             return true;
          return (bool )ViewState["avail_bus"];
       }
    }
    private int max_capacity_bus 
    {
       set { ViewState["max_capacity_bus "] = value; }
       get 
       {
          if (ViewState["max_capacity_bus "] == null)
             return 0;
          return (int)ViewState["max_capacity_bus "];
       }
    }
    private int realAvailability
    {
       set { ViewState["realAvailability"] = value; }
       get 
       {
          if (ViewState["realAvailability"] == null)
             return 0;
          return (int)ViewState["realAvailability"];
       }
    }
        protected void Page_Load (object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    BindDropDown();
    
    
                }
    
            }
    
            //Method called when dropdown is selected in Bus Stop. It helps to populate Bus Number
            protected void DropDownList4_SelectedIndexChanged (object sender, EventArgs e)
            {
    
                AutoPopulateBusStop();
                Availability();
    
            }
    
    
            //Method to load drop down values in Bus Stop. These are populated from database
            protected void BindDropDown ()
            {
               //some code here
            }
    
            //Method to autopopulate Bus Number based on selection of Bus Stop. The mapping is in the database in the table named -> dropdownlist
            protected void AutoPopulateBusStop ()
            {
                //some code here
            }
    
    
            protected void Availability ()
            {
                string constr5 = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                using (SqlConnection con5 = new SqlConnection(constr5))
                {
                    try
                    {
    
                        using (SqlCommand cmd5 = new SqlCommand("select count(*) from etms where BusNo='" + TextBox6.Text.ToString() + "'"))
                        {
                            cmd5.CommandType = CommandType.Text;
                            cmd5.Connection = con5;
                            con5.Open();
                            int capacity_from_db = Convert.ToInt16(cmd5.ExecuteScalar());
                            realAvailability = max_capacity_bus - capacity_from_db;
    
                            if (realAvailability > 0)
                            {
                                avail_bus = true;
                                TextBox2.Text = realAvailability.ToString() + " seats available ";
                                TextBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#008000");
    
                            }
                            else
                            {
    
                                TextBox2.Text = "Seats Not available. Please choose another Stop";
                                TextBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff1919");
                            }
    
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
    
                }
    
            }
    
    
            protected void Button1_Click1 (object sender, EventArgs e)
            {
    
    
                if (isNotDup)
                {
                    if (avail_bus)
                    {
                       // Submit the Form
                    }
                    else
                    {
                        Label14.Text = "Bus Seats not available!";
                        Label15.Text = null;
                    }
                }
            }
    
    
    
            protected void PhoneNumberValidatation (object source, ServerValidateEventArgs args)
            {
    
               //some code here
    
    
    
            }
    
    
             }
    }
    
     
