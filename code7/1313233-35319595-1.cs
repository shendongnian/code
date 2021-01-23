    List<ComboBox>myComboBoxList=new List<ComboBox>();
                myComboBoxList.Add(comboBox1);
                myComboBoxList.Add(comboBox2);
                //...add all your comboBoxes
    
                //and then...
    
                for (int x = 0; x < myComboBoxList.Length; x++)
                {
                    switch (myComboBoxList[x].SelectedItem.ToString())
                    {
                        case "Mass(m)":
                            mass = int.Parse(textBox1.Text);
                            break;
