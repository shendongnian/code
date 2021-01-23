        public Form1()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int[] iD = new int[400];
        public string[] timeOn = new string[400];
        public string[] timeOff = new string[400];
        public string[] dutyNo = new string[400];
        public string[] day = new string[400];
        public string[] hours = new string[400];
        //Create File Location Var
        public string fileLocation = null;
        // On Click of Add Dutys
        private void button1_Click(object sender, EventArgs e)
        {
            //Sets Progress Bar visible and prepares to increment
            pBar1.Visible = true;
            pBar1.Minimum = 1;
            pBar1.Value = 1;
            pBar1.Step = 1;
            //Stopwatch test Declared
            Stopwatch stopWatch = new Stopwatch();
            try {
                //Self Test to see if a File Location has been set for Duty document.
                if (fileLocation == null) {
                    //If not set prompts user with message box and brings up file explorer
                    MessageBox.Show("It Appears that a file location has not yet been set, Please Select one now.");
                    Stream myStream = null;
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    //Sets default Location and Default File type as .doc
                    openFileDialog1.InitialDirectory = "c:\\";
                    openFileDialog1.Filter = "All files (*.*)|*.*|Word Files (*.doc)|*.doc";
                    openFileDialog1.FilterIndex = 2;
                    openFileDialog1.RestoreDirectory = true;
                    //Waits for User to Click ok in File explorer and then Sets file location to var
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Checks to make sure a file location is set
                            if ((myStream = openFileDialog1.OpenFile()) != null)
                            {
                                using (myStream)
                                {
                                    //This is where we set location to var
                                    fileLocation = openFileDialog1.FileName;
                                }
                                //Prompts user to click a file before OK
                            }else { MessageBox.Show("Please Select a file location before clicking ok"); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Could not read file from disk: " + ex.Message);
                        }
                    }
                }
               //Loads New Duty file 
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document document = application.Documents.Open(fileLocation);
                //Begin stop watch (COPY TIME)
                stopWatch.Start();
                //Sets Count to No of sentences and then prepares Array using Number of sentences 
                //**This process reduces amount of processng time by taking everything in to the program to start and then dealing with it.
                int count = document.Sentences.Count;
                string[] sents = new string[count];
                //Then sets the Progress bar to the Number of sentences that will be Copied to our array
                pBar1.Maximum = count;
                try {
                    //For loop runs throug every sentence and adds it to the array.
                    for (int i = 0; i < count; i++) {
                        sents[i] = document.Sentences[i+1].Text;
                        //increment Progress bar by 1 for every sentence(Parse made)
                        pBar1.PerformStep();
                    }
                    //Closes our instance of word
                    application.Quit();
                    try {
                        for (int i = 0; i < count; i++)
                        {
                            //Sets our Split criteria 
                            char[] delimiterChars = { ' ','\t' };
                            string[] test = (sents[i].Split(delimiterChars));
                            //we then enter For loop that runs for the number of ords found/Split
                            for (int a = 0; a < test.Length; a++)
                            {  
                                //If tests only begin if the word is NOT a space blank, tab , - As these do parse through into our Test arrays
                                if (!(test[a] == "" || test[a].Contains("/t")|| test[a].Contains("-") || test[a].Contains(" ")))
                                {
                                    //If tests to find Duty numbers ours on off and assigns ID number for easy indexing. 
                                    //##THIS DOES ASSUME THAT OUR TIMES ARE 1 SPACE AFTER THEIR IDENTIFIERS.
                                    if (test[a] == "TG")
                                    {
                                        dutyNo[id] = test[a + 2]; 
                                    }
                                    else if (test[a] == "On")
                                    {
                                        iD[id] = id;
                                        timeOn[id] = test[a + 1];
                                    }
                                    else if (test[a] == "Off")
                                    {
                                        timeOff[id] = test[a + 1];
                                    }
                                    else if (test[a] == "Hrs")
                                    {
                                        hours[id] = test[a + 1];
                                    }
                                    else if (test[a] == "Days")
                                    {
                                        day[id] = test[a + 1];
                                        //PRINTS TO USER VIA LIST BOX ALL THE DUTYS ADDED.
                                        listBox1.Items.Add(string.Format("ADDED:Duty No:{3} Time on:{1} Time off:{2} Hours{5} Day:{4} ID:{0}", iD[id], timeOn[id], timeOff[id], dutyNo[id], day[id], hours[id]));
                                        id++;
                                    }
                                    
                                }
                            }
                        }
                    }
                    catch(Exception ex) { MessageBox.Show("Error in split:" + ex.Message); }
                }
                catch(Exception ex) { MessageBox.Show("error setting string to Document:" + ex.Message); }
                //Stopwatch Is then printed for testing purposes.
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                Console.WriteLine("RunTime (total):" + elapsedTime);
                stopWatch.Reset();
 
            }
            catch(Exception ex) { MessageBox.Show("Error in reading/finding file: "+ ex.Message); }
        }
 
    }
