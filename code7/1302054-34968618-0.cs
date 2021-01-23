    string myFileString = System.IO.File.ReadAllText(@"C:\Temp\MyFile.txt");
    
                string[] myStringArray = myFileString.Split(',');
                
                List<float> myNumberList = new List<float>();
    
                foreach (string s in myStringArray)
                {
                    myNumberList.Add(float.Parse(s.Trim()));
                }
