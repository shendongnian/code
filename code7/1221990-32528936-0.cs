      int sum = 0;           
            foreach (ListViewItem v in listView1.Items)
            {
                bool hasBlank = false;
                for (int i = 0; i < v.SubItems.Count;i++ )
                {
                    if (v.SubItems[i].Text == null || v.SubItems[i].Text == string.Empty)
                    {
                        //code
                        MessageBox.Show("error");
                        hasBlank = true;
                        break;                        
                    }
                    else
                    {
                        sum += Convert.ToInt16(v.SubItems[i].Text);
                    }
                }
                if (!hasBlank)
                {
                    string grade="something";
                    //formula to calculate grade based on sum.
                    v.SubItems[4].Text = grade;                   
                }
                else
                {
                    v.SubItems[4].Text = "has blank";
                }
                sum = 0;
            }
