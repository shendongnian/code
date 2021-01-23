            TimeSpan grandtotalTime = new TimeSpan();
            TimeSpan ts;
             foreach (ListViewItem lstItem in listView1.Items)
               {
               ts = TimeSpan.Parse(lstItem.SubItems[1].Text);
               grandtotalTime += ts; 
                }
                 textBoxListTotal.Text = Convert.ToString(grandtotalTime );
                  }
