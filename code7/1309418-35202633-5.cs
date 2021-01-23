    private void button1_Click(object sender, EventArgs e)
            {
                List<TestData> myList = new List<TestData>();
                myList.Add(new TestData() { A = "Str1", B = "Str2" });
                myList.Add(new TestData() { A = "Str3", B = "Str4" });
    
                Properties.Settings.Default["myTestDataList"] = myList;
                Properties.Settings.Default.Save();
            }
