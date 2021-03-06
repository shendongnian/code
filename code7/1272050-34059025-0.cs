    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Default2 : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
            {
                string numNights = Convert.ToString(((TextBox)PreviousPage.FindControl("txtNights")).Text);
                string arrivalDate = Convert.ToString(((TextBox)PreviousPage.FindControl("txtArrivalDate")).Text);
                
                string numAdults = Convert.ToString(((DropDownList)PreviousPage.FindControl("ddlAdults")).SelectedItem.Text);
                string numChildren = Convert.ToString(((DropDownList)PreviousPage.FindControl("ddlChildren")).SelectedItem.Text);
                string roomTypeBusiness = "false";
                string roomTypeSuite = "false";
                string roomTypeStandard = "false";
                string bedTypeKing = "false";
                string bedTypeDouble = "false";
                string smokingOption = "false";
    
                if (Convert.ToBoolean(((RadioButton)PreviousPage.FindControl("rdoBusiness")).Checked))
                    roomTypeBusiness = "true";
                else if (Convert.ToBoolean(((RadioButton)PreviousPage.FindControl("rdoSuite")).Checked))
                    roomTypeSuite = "true";
                else
                    roomTypeStandard = "true";
    
                if (Convert.ToBoolean(((RadioButton)PreviousPage.FindControl("rdoKing")).Checked))
                    bedTypeKing = "true";
                else
                    bedTypeDouble = "true";
    
                string specialRequests = Convert.ToString(((TextBox)PreviousPage.FindControl("txtSpecialRequests")).Text);
                string name = Convert.ToString(((TextBox)PreviousPage.FindControl("txtName")).Text);
                string email = Convert.ToString(((TextBox)PreviousPage.FindControl("txtEmail")).Text);
    
                lblResults.Text = String.Format("Arrival Date: {0} \r\n Number of Nights: {1} \n Number of Adults: \r {2} Number of Children: {3} Business Room: {4} Suite Room: {5} Standard Room: {6} King Bed: {7} Double Bed: {8} Smoking: {9} Special Requests: {10} Name: {11} E-mail: {12}",
                arrivalDate, numNights, numAdults, numChildren, roomTypeBusiness, roomTypeSuite, roomTypeStandard, bedTypeKing, bedTypeDouble, smokingOption, specialRequests, name, email);
            }
    
    }
