    private void openMenuItem_Click(object sender, EventArgs e)//contentmenu openbtn
        {
 
    if (listView1.SelectedIndices.Count > 0)//in listview form//on_click opnbtn   
    {
 
    string strSlctdtext=Convert.ToString(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text);
                    TextBoxform objTextBoxform = new TextBoxform(strListSelectedtext);
                    if (objTextBoxform.ShowDialog() == DialogResult.OK)
                    {
                        //do somthing if u want some output from textboxform in return
                    }
                }
            }
