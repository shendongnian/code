    private bool isLogging = false;
            private string myLog = "";
    
            //This is where the input from the sensor arrives
            private void myInput(string s)
            {
                textBox1.Text += s + "\n";
                if (isLogging)
                    myLog += s + "\n";
            }
            private void buttonOnStart_Click(object sender, EventArgs e)
            {
                //Clear log string
                myLog = "";
                //Start logging
                isLogging = true;
            }
    
            private void buttonOnStop_Click(object sender, EventArgs e)
            {
                //Stop logging
                isLogging = false;
                //Pring only the logged messages
                System.IO.File.WriteAllLines(@"C:\Users\Mohammad_Taghi\Desktop\a.txt", myLog);
            }
