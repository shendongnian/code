       public Form1()
        {
            InitializeComponent();
            // Create some people and a list to hold them.
            var personA = new Person { Name = "Kevin", Address = "140 Holiday Drive" };
            var personB = new Person { Name = "Donna", Address = "123 Somestreet" };
            var personC = new Person { Name = "Mark", Address = "145 Uptown Blvd" };
            var personD = new Person { Name = "Bryce", Address = "504 Greymere Road" };
            var personE = new Person { Name = "Parzival", Address = "99A Housing Brad St" };
            var people = new List<Person> { personA, personB, personC, personD, personE };
            //// Make a datatable to hold the people
            var tblPeople = new DataTable();
            tblPeople.Columns.Add("Name");
            tblPeople.Columns.Add("Address");
            foreach (var person in people)
            {
                tblPeople.Rows.Add(person.Name, person.Address);
            }
            
            // this line sets the state of the added rows to 'unchanged', 
            // so when you modify one row it becomes'modified'
            tblPeople.AcceptChanges();
            // Set binding source to the table
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = tblPeople;
            dataGridView1.DataSource = bindingSource1;
        }
