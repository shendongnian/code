    for (int i = 0; i < 3; i++)
    {
        StringBuilder line = new StringBuilder();
        line.Append((string)arr[i][0] + ": ");
        string[] subs = (string[])arr[i][1];
        for (int j = 0; j < 2; j++)
        {
           line.Append(subs[j] + "; ");
        }
        MessageBox.Show(line.ToString());
    }
