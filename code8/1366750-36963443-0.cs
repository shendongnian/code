    public partial class Form2 : Form
    {
        public string newFirstName;
        public string newMiddleName;
        public string newLastName;
        public string newDOB;
    
        public Form2()
        {
            InitializeComponent();
        }
        
        private Form1 m_MainForm;
        public Form2(Form1 form)
        {
            InitializeComponent();
            m_MainForm = form;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            StreamReader getLength = new StreamReader("../../../patient info.txt");
            string lineInfo = getLength.ReadLine();
    
            while (lineInfo != null)
            {
                counter++;
                lineInfo = getLength.ReadLine();
            }
            getLength.Close();
            counter++;
            StreamWriter writeNewPatient = new StreamWriter("../../../patient info.txt", true );
            writeNewPatient.WriteLine("000" + counter + ", " + tbFirstName.Text + ", " + tbMiddleName.Text + ", " + tbLastName.Text + ", " + tbDOB.Text);
            writeNewPatient.Flush();
            writeNewPatient.Close();
            Form1 frm = new Form1();
            frm.pateintNumber.Add("000" + counter);
            frm.patientFirstName.Add(tbFirstName.Text);
            frm.patientMiddleName.Add(tbMiddleName.Text);
            frm.patientLastName.Add(tbLastName.Text);
            frm.patientDOB.Add(tbDOB.Text);
            frm.counter = frm.counter++;
            
            if (!Object.ReferenceEquals(null, m_MainForm))
            {
                m_MainForm.cacheInfo(); 
            }
            this.Close(); //to turn off current app
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            if (!Object.ReferenceEquals(null, m_MainForm))
            {
               m_MainForm.cacheInfo(); 
            }
            this.Close();
        }
    } //end of program
