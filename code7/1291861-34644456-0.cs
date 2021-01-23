    try
    {
        StreamReader reader = new StreamReader("input.txt");
        string line;
        StringBuilder sum = new StringBuilder();
        int count = 0;
        while ((line = reader.ReadLine()) != null)
        {
            string[] splitted = line.Split('#');
            string first = splitted[0].Trim();
            string second = splitted[1].Trim();
                  sum.Append(first).Append(second);
        }
            txtSum.Text = sum.ToString();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
