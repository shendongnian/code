    public class Navigation : INavigation
    {
        // Properties from INavigator
        public Dictionary<string,string> CurrentRecordFields {get; set;}
        // private fields
        private string conString;
        private string tableName;
        // Constructor requires that the connection string and
        // required table name be passed as arguments.
        public Navigation(String Con_String, String Table)
        {
            conString = Con_String;
            tableName = Table;
            CurrentRecordFields = new Dictionary<string,string>();
        }
        // Note - this should really do some kind of error checking
        // and exception handling.    
        public void FirstRecord(void)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlDataAdapter DA = new SqlDataAdapter("Select * from " + tableName +"", con);
                DataSet DS = new DataSet();
                DA.Fill(DS, tableName);
                // Populate the Dictionary for the first row.
                CurrentRecordFields.Empty();
                foreach(var column in DS.Tables[tableName].Columns)
                {
                    string columnName = column.ColumnName;
                    CurrentRecordFields.Add(columnName,
                        DS.Tables[tableName].Rows[0][columnName].ToString());
                }
            }
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
            // See note above regarding error checking and exception handling.
            navigator.FirstRecord();
    
            // Update the UI from the business logic properties.
            this.TxtID.Text = navigator.CurrentRecordFields["ID"];
            this.TxtFees.Text = navigator.CurrentRecordFields["Fees"];
            this.TxtFeesHead.Text = navigator.CurrentRecordFields["FeesHead"];
            this.TxtRemarks.Text = navigator.CurrentRecordFields["Remarks"];             
        }
    
        // Etc., for the other form methods.
    }
