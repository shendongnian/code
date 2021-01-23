    private void tDeletebtn_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex != -1){
            //Put your folder name here..
            string filepath = Path.Combine(foldername, listBox1.Items[listBox1.SelectedIndex].ToString());
            if(File.Exists(filepath))
                File.Delete(filepath);            
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
