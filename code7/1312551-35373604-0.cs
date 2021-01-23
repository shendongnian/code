        for (int i = 0; i < D.Count(); i++)
        {
            comboBox1.Items.Add(D[i].name);
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(D[i].name);
            sortedvbcombo.Add(Convert.ToBase64String(encbuff), D[i].number);
        }
