    public class Navigation : INavigation
    {
        public string CurrentRecordID {get; set;}
        public string CurrentRecordFees {get; set;}
        public string CurrentRecordFeesHead {get; set;}
        public string CurrentRecordRemarks {get; set;}
    
        public void FirstRecord(void)
        {
           ConStr Constring = new ConStr();
           String CS = Constring.ConString("DBCS"); 
           using (SqlConnection con = new SqlConnection(CS))
           {
               SqlDataAdapter DA = new SqlDataAdapter("Select * from FeesHead order by ID", con);
    
               DataSet DS = new DataSet();
               DA.Fill(DS, "FeesHead");
    
               if ( i < DS.Tables["FeesHead"].Rows.Count-1)
               {
                   i++;
                   // Note that these update the properties on this class.
                   this.CurrentRecordID = DS.Tables["FeesHead"].Rows[i]["ID"].ToString();
                   this.CurrentRecordFees = DS.Tables["FeesHead"].Rows[i]["Fees"].ToString();
                   this.CurrentRecordHead = DS.Tables["FeesHead"].Rows[i]["FeesHead"].ToString();
                   this.CurrentRecordFees = DS.Tables["FeesHead"].Rows[i]["Remarks"].ToString();
               }
        
            // ... etc., as per your code.
    
        }
        // ... and the rest of the navigation methods: prev, next, last, etc.
    }
    
    public partial class NavigationForm
    {
        private Navigator {get; set;}
    
        public NavigationForm(INavigation navigator) :
            base()
        {
            this.Navigator = navigator;
        }
    
        private void CmdFirst_Click(object sender, EventArgs e)
        {
            // Use the business logic class to do the DB work.
            navigator.FirstRecord();
    
            // Update the UI from the business logic properties.
            this.TxtID.Text = navigator.CurrentRecordID;
            this.TxtFees.Text = navigator.CurrentRecordFees;
            this.TxtFeesHead.Text = navigator.CurrentRecordFeesHead;
            this.TxtRemarks.Text = navigator.CurrentRecordRemarks;             
        }
    
        // Etc., for the other form methods.
    }
