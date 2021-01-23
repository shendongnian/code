        protected void Page_Load(object sender, EventArgs e)
        {
            bindMenu();
        }
        public void bindMenu()
        {
            //ADO Code to get menu Items from Database
            //You can load it directly form DataTable or you can create a LIST with Menu Entity as i have
            string connectionstring = "";
            List<MenuItem> lstMenu = new List<MenuItem>();
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT Id,MenuName FROM TM_Menu", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lstMenu.Add(new MenuItem { ProductID = dr["Id"].ToString(), Name = dr["Name"].ToString() });
            }           
             
            _rptSubMenu.DataSource = lstMenu;
            _rptSubMenu.DataBind();
        }
    }
    public class MenuItem
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
    }
