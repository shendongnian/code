        public void EmployeeDataGrid_BiWeek(string fromData, string untilDate, Benefit[] selectedBenefits, Employee[] selectedEmployees)
        {
            InitializeComponent();
            List<string> benefit_names = new List<string>();
            int count = 0;
            // Get this employees selected benefits
            foreach (Benefit benefit in selectedBenefits)
            {
                var col = new DataGridTextColumn();
                col.Header = benefit.getName();
                benefit_names.Add(benefit.getName());
                col.Binding = new Binding(benefit.getName());
                // ^^ the above binding is based on the field name
                mainDataGrid.Columns.Add(col);
                count++;
            }
            
            // Create the grid
            foreach (Employee emp in selectedEmployees)
            {
               BiEmpGridItem item = new BiEmpGridItem(emp);
               item.BenefitName = benefit_names;
               mainDataGrid.Items.Add(item);
            }
        }
           public class BiEmpGridItem 
           {
            public string Name { get;set; }
            public string Birthday { get; set;}
            public List<string> BenefitName {get; set;}  // add this
            public BiEmpGridItem(Employee ee)
            {
                this.Name = ee.lastName + ", " + ee.firstName;
                this.Birthday = ee.getDateOfBirth();
            }
        }
