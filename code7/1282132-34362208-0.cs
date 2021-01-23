    public partial class XMLDataLoader : Form
    {
        public XMLDataLoader()
        {
            InitializeComponent();
        }
        //Function for the Add Car button to open the Add New Car window
        private void buttonAddCar_Click(object sender, EventArgs e)
        {
            AddNewCar displayNewCarWindow = new AddNewCar();
            displayNewCarWindow.ShowDialog();
            dataGridViewMainCarDisplay.Rows.Add(displayNewCarWindow.NewTrainName
                                               , displayNewCarWindow.NewTrainWidth
                                               , displayNewCarWindow.NewTrainHeight
                                               , displayNewCarWindow.NewTrainLength
                                               , displayNewCarWindow.NewTrainDeadWeight
                                               , displayNewCarWindow.NewTrainLoadCapacity);
        }
        //Function for the Remove Car button to delete the currently
            //selected car from the datagridview
        private void buttonRemoveCar_Click(object sender, EventArgs e)
        {
        }
    }
}
--------------------------------------------------------------------------------
    public partial class AddNewCar : Form
    {
        public AddNewCar()
        {
            InitializeComponent();
        }
        //Get and Private Set methods to pass textbox data to XMLDataLoader form
        public String NewTrainName { get; private set; }
        public String NewTrainWidth { get; private set; }
        public String NewTrainHeight { get; private set; }
        public String NewTrainLength { get; private set; }
        public String NewTrainDeadWeight { get; private set; }
        public String NewTrainLoadCapacity { get; private set; }
        private void buttonNewSave_Click(object sender, EventArgs e)
        {
            //Check that all textboxes have some kind of entry
            //ToDo: check the type of data so that only numbers are entered into non-name categories
            var message = String.Empty;
            if(textBoxNewName.TextLength < 1)
            {
                message += "Please enter a train name!\n";
            }
            if (textBoxNewWidth.TextLength < 1)
            {
                message += "Please enter a train width!\n";
            }
            if (textBoxNewHeight.TextLength < 1)
            {
                message += "Please enter a train height!\n";
            }
            if (textBoxNewLoadCapacity.TextLength < 1)
            {
                message += "Please enter a train length!\n";
            }
            if (textBoxNewDeadWeight.TextLength < 1)
            {
                message += "Please enter a train dead weight!\n";
            }
            if (textBoxNewLength.TextLength < 1)
            {
                message += "Please enter a train load capacity!\n";
            }
            //Save all data input by user to create a new train
            NewTrainName = textBoxNewName.Text;
            NewTrainWidth = textBoxNewWidth.Text;
            NewTrainHeight = textBoxNewHeight.Text;
            NewTrainLength = textBoxNewLoadCapacity.Text;
            NewTrainDeadWeight = textBoxNewDeadWeight.Text;
            NewTrainLoadCapacity = textBoxNewLength.Text;
            //Handle the form execution for whether or not a textbox is empty
            if (message != String.Empty)
            {
                MessageBox.Show(message);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }        
        //Function for the Cancel button to close the Add New Car window
        private void buttonNewCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
