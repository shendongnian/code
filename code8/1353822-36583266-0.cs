    //I'm assuming this is form 
    public partial class Dentist_Info : Form
    {
    	//create list of dentists here, so that it is visible thru whole form.
    	private List<Dentist> dentistList = new List<Dentist>();
    
    	public Dentist_Info(Surgery SurgeryToDisplay)
        {
    
            _formsSurgery = SurgeryToDisplay;
    
    
        }
    
        public void FillComboAndListOfDentists()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = GGJG; Initial Catalog = DentistDB; Integrated Security = True"))
            {
                SqlCommand SelectCommand = new SqlCommand("SELECT * FROM DentistInfo", conn);
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(SelectCommand);
                da.Fill(ds);
    
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(dr["DentistName"].ToString());
    
    				// creating new dentist
                    Dentist dent = new Dentist();
                    dent.Name = dr["DentistName"].ToString();
                    dent.Surname = dr["DentistSurname"].ToString();
                    //etc...
    
    				//add dentist to list
                    dentistList.Add(dent);
                }
                //conn.Close();
            }
        }
    
    
        public Dentist_Info()
        {
    
            InitializeComponent();
            FillComboAndListOfDentists();        
    
        }
    
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //use LINQ to find specific dentist in the list (btw, you should use something unique, some kind of ID, not just Name
            Dentist dent = dentistList.FirstOrDefault(d => d.Name == comboBox1.SelectedValue);
    
    		// once you have your dentist, fill all the details...
           if (dent != null)
           {
                txtDName.Text = dent.Name.ToString();
                txtDSurname.Text = dent.Surname;
                txtDDOB.Text = dent.DOB.ToString();
                txtGender.Text = dent.Gender;
                txtSalary.Text = dent.Salary.ToString();
    
            }
    
    
        }
    }
