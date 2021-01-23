    comboBox1_SelectedIndexChanged()
    {
     comboBox2.DataSource =null;
    
     if (comboBox1.SelectedIndex==1)
                {
                    comboBox2.DataSource = d.Tables["Modelos-MAN"];
                    comboBox2.ValueMember="Modelo";
                    comboBox2.DisplayMember = "Modelo";
                }
     if(comboBox1.SelectedIndex == 2)
                {
                    comboBox2.DataSource = d.Tables["Modelos-VOLVO"];
                    comboBox2.DisplayMember = "ModeloV";
                    comboBox2.ValueMember = "ModeloV";
    
                }
    }
