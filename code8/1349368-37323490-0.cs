    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Web.Configuration;
    
    namespace PermacultureOrganizer
    {
        public partial class OrchardMainWebForm : System.Web.UI.Page
        {
            //Make the SQL connections
            SqlConnection con2 = new SqlConnection(@"Data Source=SQL5018.SmarterASP.net;Initial Catalog=DB_9DE518_Permaculture;Persist Security Info=True;User ID=DB_9DE518_Permaculture_admin;Password=*****");
            public string con = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Create EventHandlers
                LinkButton btnInsert = new LinkButton();
                btnInsert.Click += new EventHandler(btnInsert_Click);
                DropDownList ddlTypeName = new DropDownList();
                ddlTypeName.SelectedIndexChanged += new EventHandler(ddlTypeName_SelectedIndexChanged);
                DropDownList ddlSpecies = new DropDownList();
                ddlSpecies.SelectedIndexChanged += new EventHandler(ddlSpecies_SelectedIndexChanged);
                DropDownList ddlVariety = new DropDownList();
                ddlVariety.SelectedIndexChanged += new EventHandler(ddlVariety_SelectedIndexChanged);
            }
        }
        protected void btnViewData_Click(object sender, EventArgs e)
        {
            //Go to OrchardViewer Page
            Response.Redirect("OrchardViewer.aspx");
        }
        protected void btnSearchData_Click(object sender, EventArgs e)
        {
            //Go to OrchardSearch Page
            Response.Redirect("OrchardSearch.aspx");
        }
        protected void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate ddlSpecies based on TypeName selection
            ddlSpecies.DataSource = RetrieveSpecies(ddlTypeName.SelectedValue);
            ddlSpecies.DataBind();
            ddlSpecies.Items.Insert(0, "Select Species");
        }
        private DataTable RetrieveSpecies(string OrchardTypeID)
        {
            //Use OrchardTypeID from TypeName selection to filter Species
            string connString = ConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
            string sql = @"SELECT OrchardItemID, OSpecies FROM tblOrchardItem WHERE OrchardTypeID = " + OrchardTypeID;
            DataTable dtSpecies = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //Initialize command object
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //Fill the result set
                    adapter.Fill(dtSpecies);
                }
            }
            return dtSpecies;
        }
        protected void ddlSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate ddlVariety based on Species selection
            ddlVariety.DataSource = RetrieveVariety(ddlSpecies.SelectedValue);
            ddlVariety.DataBind();
            ddlVariety.Items.Insert(0, "Select Variety");
        }
        private DataTable RetrieveVariety(string OrchardItemID)
        {
            //Use OrchardTypeID from Species selection to filter Variety
            string connString = ConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
            string sql = @"SELECT OrchardItemID, OVariety FROM tblOrchardItem WHERE OrchardItemID = " + OrchardItemID;
            DataTable dtVariety = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //Initialize command object
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //Fill the result set
                    adapter.Fill(dtVariety);
                }
            }
            return dtVariety;
        }
        protected void ddlVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gather additional data based on Variety selection
            int OrchardItemID = Convert.ToInt32(ddlVariety.SelectedIndex);
            BindOrchardGrid(OrchardItemID);
            //Display picture next based on Variety selection
            string Variety = ddlVariety.SelectedItem.ToString();
            switch (Variety)
            {
                case "Bladen":
                    imageTree.ImageUrl = "Images/blueberry-vine 300x200.jpg";
                    break;
                case "Bartlett":
                    imageTree.ImageUrl = "Images/Pear-Tree 300x200.jpg";
                    break;
                case "Babcook":
                    imageTree.ImageUrl = "Images/peach-tree-w-fruit 300x200.jpg";
                    break;
                case "Abbuoto":
                    imageTree.ImageUrl = "Images/grape-vine 300x200.jpg";
                    break;
                case "Carya":
                    imageTree.ImageUrl = "Images/pecans 300x200.jpg";
                    break;
            }
        }
        private void BindOrchardGrid(int OrchardItemID)
        {
            DataSet dtLabels;
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblOrchardItem WHERE OrchardItemID = " + OrchardItemID, con2);
            sda.SelectCommand = cmd;
            dtLabels = new DataSet("OrchardItem");
            sda.Fill(dtLabels, "OrchardItem");
            foreach (DataRow row in dtLabels.Tables["OrchardItem"].Rows)
            {
                //Gather other pertinent data based on Variety selected
                lblTreeSpacing.Text = Convert.ToString(row["OTreeSpacing"]);
                lblFertilizingTimes.Text = Convert.ToString(row["OFertilizingTimes"]);
                lblPruningTimes.Text = Convert.ToString(row["OPruningTimes"]);
                lblWateringNeeds.Text = Convert.ToString(row["OWateringNeeds"]);
                lblPollination.Text = Convert.ToString(row["OPollination"]);
                int FertilizerID = Convert.ToInt32(row["FertilizerID"]);
                int PesticideID = Convert.ToInt32(row["PesticideID"]);
                DataSet dtFert;
                SqlDataAdapter sdaF = new SqlDataAdapter();
                SqlCommand cmdF = new SqlCommand("SELECT * FROM tblFertilizer WHERE FertilizerID = " + FertilizerID, con2);
                sdaF.SelectCommand = cmdF;
                dtFert = new DataSet("Fert");
                sdaF.Fill(dtFert, "Fert");
                foreach (DataRow rowF in dtFert.Tables["Fert"].Rows)
                {
                    lblFertilizer.Text = Convert.ToString(rowF["FertilizerName"]);
                }
                DataSet dtPest;
                SqlDataAdapter sdaP = new SqlDataAdapter();
                SqlCommand cmdP = new SqlCommand("SELECT * FROM tblPesticide WHERE PesticideID = " + PesticideID, con2);
                sdaP.SelectCommand = cmdP;
                dtPest = new DataSet("Pest");
                sdaP.Fill(dtPest, "Pest");
                foreach (DataRow rowP in dtPest.Tables["Pest"].Rows)
                {
                    lblPesticide.Text = Convert.ToString(rowP["PesticideName"]);
                }
            }
        }
        public void btnInsert_Click(object sender, EventArgs e)
        {
            //After the user inputs data, insert it into the database and then switch to OrchardViewer page
            CreateOrchard(con);
            Response.Redirect("OrchardViewer.aspx");
        }
        public DataTable CreateOrchard(string con)
        {
            DataTable dtOrchard = new DataTable();
            using (SqlConnection Connection = new SqlConnection(con))
            {
                SqlCommand sqlcmd = new SqlCommand();
                //associate command object with connection
                sqlcmd.Connection = Connection;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "spInsertOrchardData";
                //Gather user input for insert into database
                sqlcmd.Parameters.Add("@UserOrchardID", SqlDbType.VarChar, 1000).Value = "";
                sqlcmd.Parameters.Add("@TypeName", SqlDbType.VarChar, 1000).Value = Convert.ToString(ddlTypeName.SelectedItem);
                sqlcmd.Parameters.Add("@Species", SqlDbType.VarChar, 1000).Value = Convert.ToString(ddlSpecies.SelectedItem);
                sqlcmd.Parameters.Add("@Variety", SqlDbType.VarChar, 1000).Value = Convert.ToString(ddlVariety.SelectedItem);
                sqlcmd.Parameters.Add("@Age", SqlDbType.Int, 1000).Value = Convert.ToInt32(txtBxAge.Text);
                sqlcmd.Parameters.Add("@Yields", SqlDbType.VarChar, 1000).Value = Convert.ToInt32(txtBxYields.Text);
                sqlcmd.Parameters.Add("@PlantDate", SqlDbType.VarChar, 1000).Value = Convert.ToString(txtBxPlantDate.Text);
                sqlcmd.Parameters.Add("@PlantFrom", SqlDbType.VarChar, 1000).Value = Convert.ToString(txtBxPlantFrom.Text);
                sqlcmd.Parameters.Add("@TreeSpacing", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblTreeSpacing.Text);
                sqlcmd.Parameters.Add("@FertilizingTimes", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblFertilizingTimes.Text);
                sqlcmd.Parameters.Add("@PruningTimes", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblPruningTimes.Text);
                sqlcmd.Parameters.Add("@WateringNeeds", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblWateringNeeds.Text);
                sqlcmd.Parameters.Add("@Pollination", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblPollination.Text);
                sqlcmd.Parameters.Add("@Fertilizer", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblFertilizer.Text);
                sqlcmd.Parameters.Add("@Pesticide", SqlDbType.VarChar, 1000).Value = Convert.ToString(lblPesticide.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlcmd))
                {
                    DataSet dataset = new DataSet();
                    sda.Fill(dataset);
                }
            }
            return dtOrchard;
        }
    }
}
