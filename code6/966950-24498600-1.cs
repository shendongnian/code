    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Data.SqlClient;
    namespace SiteMaintenance
    {
    public partial class MainWindow : Window
    {
        /**
         * CLASS VARIABLES
         * */
        private SqlConnection localdbConnection;        // Connection to Site Maintenance DB (LOCAL)
        private System.Data.DataSet allSitesResults;
        // MAIN THREAD
        public MainWindow()
        {
            InitializeComponent();
            
            // try to open SQL Connection
            try {
                localdbConnection = new SqlConnection(Properties.Settings.Default.localdb);
                localdbConnection.Open();
            } catch(Exception ex) {
               System.Windows.MessageBox.Show("local SQL connection unable to connect");
               return;
            }
            viewHistory_BTN.IsEnabled = false;
            startMaintenance_BTN.IsEnabled = false;
            startMaintenance_BTN.IsDefault = true;
        }
        /**
         * Load dataset into datagrid 
         * LAZY LOADING
         * */
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // init command object
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "dbo.usp_GetSites";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Connection = localdbConnection;
            // init data adaptor
            SqlDataAdapter sites = new SqlDataAdapter();
            sites.SelectCommand = myCommand;
            //init DataSet
            allSitesResults = new System.Data.DataSet();
            
            sites.Fill(allSitesResults, "tblSites");
            int tableCount = allSitesResults.Tables.Count;
            System.Data.DataTable test = allSitesResults.Tables[0];
            int rowCount = test.Rows.Count;
        }
        private void sites_DG_CurrentCellChanged(object sender, EventArgs e)
        {
            String siteName = allSitesResults.Tables[0].Rows[0][1].ToString();
        }
        private void allSites_LB_Loaded(object sender, RoutedEventArgs e)
        {
            // init command object
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "dbo.usp_GetSitesANDCompletedDate";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            myCommand.Connection = localdbConnection;
            // init data adaptor
            SqlDataAdapter sites = new SqlDataAdapter();
            sites.SelectCommand = myCommand;
            //init DataSet
            allSitesResults = new System.Data.DataSet();
            sites.Fill(allSitesResults, "tblSites");
            allSites_LB.ItemsSource = allSitesResults.Tables["tblSites"].DefaultView;
        }
        // do not allow selection of maintenance records that do not exist
        private void allSites_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // grab the index
            int selectedIndex = allSites_LB.SelectedIndex;
            if (selectedIndex == -1) return;                //WITHOUT THIS CHECK, UN-SELECTION WILL CAUSE LOGIC FAILURE
            System.Data.DataRowView tempData = (System.Data.DataRowView)allSites_LB.Items[allSites_LB.SelectedIndex];
            // grab the completed date field
            String completedDate = tempData["CompletedDate"].ToString();
            String siteMaintID = tempData["SiteMaintID"].ToString();
            // remove selected index if completed date and site Maint ID is null
            if (siteMaintID != "" && completedDate == "")
            {
                startMaintenance_BTN.IsEnabled = true;
            }
            else 
            {
                allSites_LB.SelectedIndex = -1;
                startMaintenance_BTN.IsEnabled = false;
            }
            
        }
        private String maintRequired(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = allSites_LB.SelectedIndex;
            if (selectedIndex < 0) return null;
            System.Data.DataRowView tempData = (System.Data.DataRowView)allSites_LB.Items[allSites_LB.SelectedIndex];
            // grab the completed date field
            String completedDate = tempData["CompletedDate"].ToString();
            String siteMaintID = tempData["SiteMaintID"].ToString();
            if (siteMaintID != "" && completedDate == "")
            {
                return "Maintenance Required";
            }
            else
            {
                return "No Maintenance";
            }
        }
    }
    public class MaintenenceColorConverter : IValueConverter
    {
        public Color NormalColor { get; set; }
        public Color NoMaintenanceRequiredColor { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "No Maintenance Required") return NoMaintenanceRequiredColor.ToString();
            return NormalColor.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
