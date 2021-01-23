    private void ReadIntoArray()
    {
        try
        {
            const int SIZE = 16;
            string[] titleArray = new string[SIZE];
            double[] salesArray = new double[SIZE];
            int index = 0;
            StreamReader inputFile = File.OpenText("GameSales.txt");
                
               
            while (index < titleArray.Length && !inputFile.EndOfStream)
            {
                string title = inputFile.ReadLine(); //Note the moving of the file readline into the while statement
                string[] temp = title.Split('@', '='); //Also used a temporary variable to hold the value of the split before assigning it to the array.
                titleArray[index] = temp[0];
                salesArray[index] = double.Parse(temp[1]);
                index++;
            }
            foreach (string value in titleArray)
            {
                detailsListBox.Items.Add(value);
            }
            inputFile.Close();
        }
        catch
        {
            MessageBox.Show("Error");
        }
    }
