	private void button1_Click(object sender, EventArgs e)
    {
         try
        {
            OpenFileDialog fop = new OpenFileDialog();
            fop.InitialDirectory = "C:\\";
            fop.Filter = "[JPG,JPEG]|*.jpg";
            if (fop.ShowDialog() == DialogResult.OK)
            {
				ImageService.SaveImage(fop.FileName);
			}
		}
		catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
	}
	private void button2_Click(object sender, EventArgs e)
	{
    
		comboBox1.DataSource = ImageService.GetAllImageIDs();
		comboBox1.DisplayMember = "ID";
		comboBox1.ValueMember = "ID";
	}
