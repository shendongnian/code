    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Izveleties atputas vietu
            if(comboBox2.SelectedText == "Zemgale")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Jelgava");
            }
            // Izveleties atputas vietu
            if (comboBox2.SelectedText == "Latgale")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Daugavpils");
            }
        }
