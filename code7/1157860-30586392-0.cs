    void Page_Load(Object sender, EventArgs e)
      {
            if (DDLlist==null)
            {
              MaxMinSkillLevel minMax = CompetencyManager.GetMaxAndMinSKillLevelBySkillName(lblname.Text);
              DDLlist = new List<string>();
              for (int i = Int32.Parse(minMax.minimumLevel); i < Int32.Parse(minMax.maximumLevel); i++)
              {
                DDLlist.Add((i + 1).ToString());
              }
            }
         // Load data for the DropDownList control only once, when the 
         // page is first loaded.
         if(!IsPostBack)
         {
            // Specify the data source
            YourDropDownList.DataSource = DDLlist;
            // Bind the data to the control.
            YourDropDownList.DataBind();
            // Set the default selected item, if desired.
            YourDropDownList.SelectedIndex = 0;
         }
      }
