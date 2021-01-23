    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplication1
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    			var selectedBenefits = Enumerable.Range(1, 10).Select(n => new Benefit { Name = "Benefit" + n }).ToArray();
    			var selectedEmployees = Enumerable.Range(1, 20).Select(n => new Employee
    			{
    				firstName = "FirstName" + n,
    				lastName = "LastName" + n,
    				dateOfBirth = "DateOfBirth" + n,
    				benefits = selectedBenefits.Select((b, i) => "B[" + n + ", " + i + "]").ToArray()
    			}).ToArray();
    			dataGrid.AutoGenerateColumns = false;
    			dataGrid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
    			dataGrid.Columns.Add(new DataGridTextColumn { Header = "Birthday", Binding = new Binding("Birthday") });
    			for (int i = 0; i < selectedBenefits.Length; i++)
    				dataGrid.Columns.Add(new DataGridTextColumn { Header = selectedBenefits[i].getName(), Binding = new Binding("Benefits[" + i + "]") });
    			foreach (var emp in selectedEmployees)
    				dataGrid.Items.Add(new BiEmpGridItem(emp));
    		}
    	}
    	public class Benefit
    	{
    		public string Name { get; set; }
    		public string getName() { return Name; }
    	}
    	public class Employee
    	{
    		public string firstName, lastName;
    		public string dateOfBirth;
    		public string getDateOfBirth() { return dateOfBirth; }
    		public string[] benefits;
    	}
    	public class BiEmpGridItem
    	{
    		public string Name { get; set; }
    		public string Birthday { get; set; }
    		public string[] Benefits { get; private set; }
    		public string GetBenefit(int index) { return Benefits[index]; }
    		public BiEmpGridItem(Employee ee)
    		{
    			this.Name = ee.lastName + ", " + ee.firstName;
    			this.Birthday = ee.getDateOfBirth();
    			this.Benefits = ee.benefits;
    		}
    	}
    }
