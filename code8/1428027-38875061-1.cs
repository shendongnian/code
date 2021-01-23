        public Form1()
        {
            InitializeComponent();
            ReWriteFile(@"M:\StackOverflowQuestionsAndAnswers\38873875\38873875\testdata.csv");//call the method
        }
        public void ReWriteFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(@"M:\StackOverflowQuestionsAndAnswers\38873875\38873875\testdata_new.csv"))
            {
                string currentLine = string.Empty;
                using (StreamReader sr = new StreamReader(fileName))//
                {
                    while ((currentLine = sr.ReadLine()) != null)//while there are lines to read
                    {
                        string[] fielded = currentLine.Split(',');//split your fields into an array
                        fielded[4] = fielded[4].Replace(" ", ",");//replace the space in position 4(field 5) of your array
                        sw.WriteLine(string.Join(",", fielded));//write the line in the new file
                    }
                }
            }
        }
