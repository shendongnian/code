    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString);
    conn.Open();
    
    short North = CheckBoxList2.Items.FindByText("North ").Selected;
    short West = CheckBoxList2.Items.FindByText("West ").Selected;
    short South = CheckBoxList2.Items.FindByText("South ").Selected;
    short East = CheckBoxList2.Items.FindByText("East ").Selected;
    
    string insertcheckboxlist = "insert into Destinations (North,West,South,East) values(" + North.ToString + "," + West.ToString + "," + South.ToString + "," + East.ToString + ")";
