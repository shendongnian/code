    private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
    	if (listView1.SelectedIndices.Count == 0)
    	{
    		return;
    	}
    	pictureBox1.Image = Image.FromFile(resimKonumu[listView1.SelectedIndices[0]]);
    }
