    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    LoadCarsList();
                    
                }
            }
    
    
            protected void lbCars_SelectedIndexChanged(object sender, EventArgs e)
            {   
                //this will be executed when selected item in list of cars is changes
                //load parts
                LoadPartsList(this.lbCars.SelectedValue);
            }
    
            protected void LoadCarsList()
            {
                //here is the place to load cars list from database.
                //for this example, cars are hard-coded
                this.lbCars.Items.Clear();
                this.lbCars.Items.Add(new ListItem("Peugeot", "1"));
                this.lbCars.Items.Add(new ListItem("VW", "2"));
                this.lbCars.Items.Add(new ListItem("Ford", "3"));
                this.lbCars.Items.Add(new ListItem("Fiat", "4"));
            }
    
            protected void LoadPartsList(string carId)
            {
                //this will be called when you s
                this.lbParts.Items.Clear();
    
                this.lbParts.Items.Add("part one for car " + carId);
                this.lbParts.Items.Add("part two for car " + carId);
                this.lbParts.Items.Add("part three for car " + carId);
                
            }
        }
    }
