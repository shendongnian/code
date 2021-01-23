     while (dr.Read())
                {
                    //Iterate through each check box in teacher check list box to see which one is checked
                    for (int i = 0; i < teacherCheckListBox.Items.Count; i++)
                {
                    if (teacherCheckListBox.GetItemChecked(i))
                    {
                        string str = (string)teacherCheckListBox.Items[i];
                     
                            string l_Name = dr.GetString(5);
                            string f_Name = dr.GetString(6);
                            xlTeacherDetail.Cells[2 + i, 2] = f_Name;
                            xlTeacherDetail.Cells[2 + i, 3] = l_Name;
                            xlTeacherDetail.Cells[2 + i, 4] = str;
                  
                           
                        }
                 
                    }
