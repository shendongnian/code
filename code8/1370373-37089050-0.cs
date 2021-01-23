    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Ports;
    namespace AGAING
    {
        public partial class Form1 : Form
        {
           // int[] OUT = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // The array must be send by AUNO the resend to it.
            byte[] OUT = new byte[12];
            byte lamp = 0; // The index of lamp type array, and the indecation of the lamp type in the OUT array ti the AUNO.
            string[] lampType = { "ENERGY SAVER", "TUNGSTEN", "FLUORESCENT", "METAL HALIDE" }; // Array for lamp type identification.
    
            int sample; // The index of the report matrix, and giving number of test we did.
            int[] endsample = new int [12]; //index array for saving the ended sample date.
    
            int reportlenth = 3; // lenth of reporting arrays
            string[] smplNo = new string[3]; //Array for sample number reporting.
            string[] smpltype = new string[3]; // Array for sample lamp type reporting.
            string[] startdate = new string[3]; // Array for sample starting date reporting.
            string[] enddate = new string[3]; // Array for sample ending date reporting.
            
            public Form1()
            {
                InitializeComponent();
             //   getportnames();   
                //serialPort1.Open();
                
            }
    
          //  void getportnames()
            //{
              // string[] port = SerialPort.GetPortNames();
               //PortcomboBox1.Items.AddRange(port);
                
           // }
    
            void warning(string warning) // Worning message properties.
            {
                MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                serialPort1.Open();
            }
    
            private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
            {
                serialPort1.Close();
            }
    
            private void lamptype_SelectedIndexChanged(object sender, EventArgs e) // Projection the combo box of lamp type to the OUT Array
            {
                if (lamptype.SelectedIndex == 0)
                { lamp = 1; }
                else if (lamptype.SelectedIndex == 1)
                { lamp = 2; }
                else if (lamptype.SelectedIndex == 2)
                { lamp = 3; }
                else if (lamptype.SelectedIndex == 3)
                { lamp = 4; }
                else if (lamptype.SelectedIndex == -1)
                { lamp = 0; }
            }
    
            private void out1_CheckedChanged_1(object sender, EventArgs e)
            {
                if (out1.Checked)
                {// If check box selected change its properties
                    out1.Font = new Font(out1.Font, FontStyle.Bold);
                    //Change text box properties.
                    sampleno1.Clear();
                    sampleno1.Enabled = true;
                    //Change text box properties.
                    enddate1.Clear();
                    datetime1.Clear();
                    lamptype1.Clear();
                }
                else {// unless reset the check box
                    out1.Font = new Font(out1.Font, FontStyle.Regular);
                    //Change text box properties.
                    sampleno1.Enabled = false;
                    // Reset the lamp type selection.
                    lamptype.SelectedIndex = -1;
                    lamptype.Text = "__Select lamp type__";
                }
                //
                serialPort1.Write(OUT, 0, 12);
            }
    
            private void run1_Click_1(object sender, EventArgs e)
            {//Check if any data are not marked give wornings.
                if (out1.Checked == false) { warning("Select output"); }
                else if (lamptype.SelectedIndex < 0) { warning("Select Lamp Type"); }
                else if (String.IsNullOrEmpty(sampleno1.Text)) { warning("Enter sample number"); }
                else if (sampleno1.TextLength != 10) { warning("Enter sample number correctly"); }
                else
                {// If yes change check box properties  
                    out1.Enabled = false;
                    // Change run button properties  
                    run1.Text = "In Use";
                    run1.Enabled = false;
                    run1.BackColor = Color.LightGreen;
                    run1.Font = new Font(run1.Font, FontStyle.Bold);
                    // Change text box properties  
                    sampleno1.Enabled = false;
                    // Change stop button properties  
                    stop1.Enabled = true;
                    stop1.BackColor = Color.OrangeRed;
                    stop1.Font = new Font(stop1.Font, FontStyle.Bold);
                    // Marking lamp type na d aoth data in text bos and reset lamp type combo box 
                    lamptype1.Text = lampType[lamp - 1];
                    lamptype.Text = "__Select lamp type__";
                    // Show the starting date. 
                    datetime1.Text = DateTime.Now.ToString("dd/mm/yyyy, hh:mm:ss");
                    // Save the sample data.
                    smplNo[sample] = sampleno1.Text;    // Save the sample number.
                    smpltype[sample] = lamptype1.Text;  // Save the lamp type date.
                    startdate[sample] = datetime1.Text; // Save the starting date.
                    // Save the reporting index for the ending date.
                    endsample[0] = sample;
                    // Increase the reporting index to give the sample counter and show it.
                    sample++;
                    MessageBox.Show("This is test no. " + sample);
                    // Worning to reset the saving data arraies. the reset it.
                    if (sample == reportlenth - 1)
                    { warning("Only 1 more sample and the reporting system will reset, please inform the responsible"); }
                    else if (sample == reportlenth)
                    { warning("The reporting system will reset, please inform the responsible");
                        sample = 0; }
                    //******************************************************************************//
                    // Set the output lamp type in the OUT array for AUNO.
                    OUT[0] = lamp;
                }
                //
                //serialPort1.WriteLine("$");
                serialPort1.Write(OUT, 0, 12);
            }
