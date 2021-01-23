	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Data;
	using System.Data.SqlClient;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Navigation;
	using System.Windows.Shapes;
	namespace DatabaseManagement
	{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Database db = new Database();
		public MainWindow()
		{
			InitializeComponent();
			// Add the loadCombo back
			loadCombo();
			// comment this out until you get the desired functionality  
			//TableCreateGrid.Visibility = Visibility.Hidden;
		}
		private void createButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
			// I am not sure what you are doing here -  
				if (string.IsNullOrEmpty(column3TextBox.Text) && string.IsNullOrEmpty(column4TextBox.Text))
				{
					db.CreateTable(tableTextBox.Text, column1TextBox.Text, column2TextBox.Text);
					informationBlock.Text = db.infoBoxString;
				}
				else if (string.IsNullOrEmpty(column4TextBox.Text))
				{
					db.CreateTable(tableTextBox.Text, column1TextBox.Text, column2TextBox.Text, column3TextBox.Text);
					informationBlock.Text = db.infoBoxString;
				}
				else if (!string.IsNullOrEmpty(column3TextBox.Text) && !string.IsNullOrEmpty(column4TextBox.Text))
				{
					db.CreateTable(tableTextBox.Text, column1TextBox.Text, column2TextBox.Text, column3TextBox.Text, column4TextBox.Text);
					informationBlock.Text = db.infoBoxString;
				}
			}
			catch (Exception ex)
			{
				informationBlock.Text = ex.Message;
			}
		}
		private void button_Click(object sender, RoutedEventArgs e)
		{
			db.Connect();
			informationBlock.Text = db.infoBoxString;
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			db.Close();
			informationBlock.Text = db.infoBoxString;
		}
		private void loadCombo()
		{
			SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';", db.connection);
			SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet);
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				tableComboBox.Items.Add(row[0]);
			}
		}
		private DataTable loadDataGrid(String inTableName)
		{
			//  Here you need to specify the columns you want in the TableCreateGrid
			//  example  this just will show the COLUMN NAME,DATA TYPE, CHARACTER MAXIMUM LENGTH and so on
			//  SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME,DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, TABLE_SCHEMA FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + inTableName + "';", db.connection);
			SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + inTableName + "';", db.connection);
			SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet);
			return dataSet.Tables[0];
		}
		private void tableComboBox_DropDownOpened(object sender, EventArgs e)
		{
			//loadCombo();
			// dont need since this is loaded on Initialize
		}
		private void tableComboBox_DropDownClosed(object sender, EventArgs e)
		{
		  //  tableComboBox.Items.Clear();
		  // dont need since this will clear all the items in the tableComboBox
		}
		private void tableComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				string text = e.AddedItems[0].ToString(); ;
				dataGrid.ItemsSource = loadDataGrid(e.AddedItems[0].ToString()).DefaultView;
			}
			 
			catch (Exception ex)
			{
				informationBlock.Text = ex.Message;
			}
		}
	}
	}    
