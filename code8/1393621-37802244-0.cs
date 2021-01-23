    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            // the list of EDFiles 
            public List<EDIFile> EDFiles { get; set; }
            public Form1()
            {
                InitializeComponent();
                Load += Form1_Load; // add Form Load eventhandler
            }
            /// <summary>
            /// Called when the form is loaded
            /// </summary>
            private void Form1_Load(object sender, EventArgs e)
            {
                // get dummy data
                EDFiles = GetDataGridViewData();
                // set datasource to the dummy data
                dataGridView1.DataSource = EDFiles;
            }
            /// <summary>
            /// Returns dummy data for the datagridview
            /// </summary>
            /// <returns></returns>
            private List<EDIFile> GetDataGridViewData()
            {
                // bascially just creates dummy data for the example,
                // you'll need to implement based on how you need it to be
                var newEDFiles = new List<EDIFile>();
                Random random = new Random();
                for (int i = 1; i <= 10; i++)
                {
                    int randomNumber = random.Next(0, 100);
                    var infileDateTime = DateTime.Now;
                    var outfileDateTime = infileDateTime.AddDays(randomNumber);
                    var edfile = new EDIFile()
                    {
                        fullInFilePath = "fullInFilePath" + i,
                        fullOutFilePath = "fullOutFilePath" + i,
                        InfileName = "InfileName" + i,
                        OutfileName = "InfileName" + i,
                        UniqueID = "UniqueID" + i,
                        infileDateTime = infileDateTime,
                        outfileDateTime = outfileDateTime,
                        timeDiff = outfileDateTime- infileDateTime
                    };
                    newEDFiles.Add(edfile);
                }
                return newEDFiles;
            }
        }
        public class EDIFile
        {
            public string fullInFilePath { get; set; }
            public string fullOutFilePath { get; set; }
            public string InfileName { get; set; }
            public string OutfileName { get; set; }
            public string UniqueID { get; set; }
            public DateTime infileDateTime { get; set; }
            public DateTime outfileDateTime { get; set; }
            public TimeSpan timeDiff { get; set; }
        }
    }
