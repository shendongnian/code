        public EmployeeDataGrid_BiWeek(string fromData, string untilDate, Benefit[] selectedBenefits, Employee[] selectedEmployees)
        {
            InitializeComponent();
            string[] benefit_name = new string[selectedBenefits.count()];
            int count = 0;
            foreach (Benefit benefit in selectedBenefits)
            {
                var col = new DataGridTextColumn();
                col.Header = benefit.getName();
                benefit_name[count] = benefit.getName();
                col.Binding = new Binding(benefit.getName());
                // ^^ the above binding is based on the field name
                mainDataGrid.Columns.Add(col);
                count++;
            }
            
            foreach (Employee emp in selectedEmployees)
            {
               BigEmpGridItem item = new BiEmpGridItem(emp);
               int x = ????;   // The number of the benefit for this employee
               item.BenefitName = benefit_name[x];
                mainDataGrid.Items.Add(item);
            }
        }
        public class BiEmpGridItem {
            public string Name { get;set; }
            public string Birthday { get; set;}
            public string BenefitName {get; set;}  // add this
            public BiEmpGridItem(Employee ee)
            {
                this.Name = ee.lastName + ", " + ee.firstName;
                this.Birthday = ee.getDateOfBirth();
            }
        }
    }
