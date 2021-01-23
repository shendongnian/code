    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            const int Size = 10; 
            double[] numbers = new double[Size];
            int index = 0; 
            StreamReader inputFile; 
            inputFile = File.OpenText("Sales.txt");
            while(index < numbers.Length && !inputFile.EndOfStream)
            {
                numbers[index] = double.Parse(inputFile.ReadLine());
                index++;
            }
            inputFile.Close();
            foreach(double value in numbers)
            {
                listBox1.Items.Add(value);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
