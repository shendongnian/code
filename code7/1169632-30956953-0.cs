        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                //Setup the wheel choices to be selected from the DataGridViewComboBoxColumn.
                CarPartChoice myWheelChoice = new CarPartChoice("Chrome", 19, "This is the chromes wheels option.");
                CarPartChoice myWheelChoice2 = new CarPartChoice("HubCaps", 16, "This is the nasty plastic hubcaps option.");
                CarPartChoice myWheelChoice3 = new CarPartChoice("Iron", 15, "These are metal wheels.");
                CarPartChoice myWheelChoice4 = new CarPartChoice("Spoked", 15, "This is the fancy classic hubcaps option.");
                CarPartChoice myWheelChoice5 = new CarPartChoice("solid", 13, "This wheels has no spokes or holes.");
                CarPartChoice myWheelChoice6 = new CarPartChoice("SpaceHubCaps", 17, "Newly developed space hubcaps.");
                BindingList<CarPartChoice> tempBLChoice = new BindingList<CarPartChoice>();
                tempBLChoice.Add(myWheelChoice);
                tempBLChoice.Add(myWheelChoice2);
                tempBLChoice.Add(myWheelChoice3);
                tempBLChoice.Add(myWheelChoice4);
                tempBLChoice.Add(myWheelChoice5);
                tempBLChoice.Add(myWheelChoice6);
                GlobalVariables.GlobalChoiceList = tempBLChoice;
                //Setup the cars to populate the datagridview.
                Car car1 = new Car("Vauxhall", "Astra");
                Car car2 = new Car("Mercedes", "S-class");
                BindingList<Car> tempListCars = new BindingList<Car>();
                tempListCars.Add(car1);
                tempListCars.Add(car2);
                GlobalVariables.GlobalCarsList = tempListCars;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
                //dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                // Set up 2 DataGridViewTextBox columns, one to show the manufacturer and the other to show the model.
                DataGridViewTextBoxColumn manufacturer_col = new DataGridViewTextBoxColumn();
                manufacturer_col.DataPropertyName = "Manufacturer";
                manufacturer_col.Name = "Manufacturer";
                manufacturer_col.HeaderText = "Manufacturer";
                DataGridViewTextBoxColumn model_col = new DataGridViewTextBoxColumn();
                model_col.DataPropertyName = "Model";
                model_col.Name = "Model";
                model_col.HeaderText = "Model";
                // Create a DataTable to hold the Wheel options available for the user to choose from. This DT will be the DataSource for the 
                //  ...combobox column
                DataTable wheelChoices = new DataTable();
                DataColumn choice = new DataColumn("Choice", typeof(CarPartChoice));
                DataColumn choiceDescription = new DataColumn("Description", typeof(String));
                wheelChoices.Columns.Add(choice);
                wheelChoices.Columns.Add(choiceDescription);
                foreach (CarPartChoice wheelchoice in GlobalVariables.GlobalChoiceList)
                {
                    wheelChoices.Rows.Add(wheelchoice, wheelchoice.Name + " - " + wheelchoice.Value.ToString() + " - " + wheelchoice.Comment);
                }
                // Create the Combobox column, populated with the wheel options so that user can pick one.
                DataGridViewComboBoxColumn wheelOption_col = new DataGridViewComboBoxColumn();
                wheelOption_col.DataPropertyName = "WheelChoice";
                wheelOption_col.DataSource = wheelChoices;
                wheelOption_col.ValueMember = "Choice";
                wheelOption_col.DisplayMember = "Description";
                wheelOption_col.ValueType = typeof(CarPartChoice);
                // Add the columns and set the datasource for the DGV.
                dataGridView1.Columns.Add(manufacturer_col);
                dataGridView1.Columns.Add(model_col);
                dataGridView1.Columns.Add(wheelOption_col);
                dataGridView1.DataSource = GlobalVariables.GlobalCarsList;
            }
            void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                var grid = sender as DataGridView;
                if (grid.IsCurrentCellDirty)
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        public class CarPartChoice
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public string Comment { get; set; }
            public CarPartChoice(string name, int value, string comment)
            {
                Name = name;
                Value = value;
                Comment = comment;
            }
            public override string ToString()
            {
                return Name.ToString() + " - " + Value.ToString() + " - " + Comment.ToString();
            }
        }
        public class Car
        {
            public string Manufacturer { get; set; }
            public string Model {get; set; }
            public CarPartChoice WheelChoice { get; set; } 
            public Car(string maker, string model, CarPartChoice wheel)
            {
                Manufacturer = maker;
                Model = model;
                WheelChoice = wheel;
            }
            public Car(string maker, string model)
            {
                Manufacturer = maker;
                Model = model;
            }
        }
        public static class GlobalVariables
        {
            public static BindingList<CarPartChoice> GlobalChoiceList { get; set; }
            public static BindingList<Car> GlobalCarsList { get; set; }
        }
