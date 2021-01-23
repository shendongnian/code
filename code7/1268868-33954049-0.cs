    class MyClass
    {
        static string divContent;
        static DateTime compareTime;
        private void timerGrip_Tick(object sender, EventArgs e)
        {
            if (File.Exists("yourFile.htm"))
            {
                DateTime tempDateTime = File.GetLastWriteTime("yourFile.htm");
                if (tempDateTime != compareTime)
                {
                    compareTime = tempDateTime;
                    GetDivContent();
                }
            }
        }
        private void GetDivContent()
        {
            string tempString = string.Empty;
            StreamReader reader = new StreamReader("yourFile.htm");
            while (!reader.EndOfStream)
            {
                tempString = reader.ReadLine();
                if (tempString.Contains("<div id=\"myDiv\""))
                    break;
            }
            if (!string.IsNullOrEmpty(tempString))
                divContent = tempString.Substring(31, tempString.Length - 37);
            reader.Close();
        }
    }
