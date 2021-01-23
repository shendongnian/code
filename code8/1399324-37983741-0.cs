    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    public static void EnableControls(this Page page, ControlCollection ctrl)
    {
        if (ctrl == null)
            ctrl = page.Controls;
        string validMooring = "";
        comm = new SqlCommand("SELECT * FROM dbo.StructureCurrent", conn);
        conn.Open();
        reader = comm.ExecuteReader();
        while (reader.Read())
        {
          validMooring = reader["StructureMooring"].ToString();
        }
        foreach (Control item in ctrl)
        {
            if (item.Controls.Count > 0)
                EnableControls(page, item.Controls, isEnable);
            if (item.GetType() == typeof(ImageButton))
            {
                switch (validMooring)
                {
                  case "YES":
                    ((ImageButton)item).Enabled = true;
                    ((ImageButton)item).ImageUrl = "~/Item/RibbonIcon/Dashboard.png";
                     break;
                  case "NO":
                    ((ImageButton)item).Enabled = false;
                    ((ImageButton)item).ImageUrl = "~/Item/RibbonIcon - Grey/DashboardGrey.png";
                    break;
                default:
                    break;
            }
           
        }
    }
