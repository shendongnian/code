    //put an else after your if    
                foreach (CheckBox checkBox in myCheckBoxArray )
                {    
                    if (checkBox .Text == className && comboBox1.SelectedIndex == index) {    
                        checkBox .Checked = true;        
                    }
                    else
                    {
                         checkBox .Enabled= false;
                    }
                }
