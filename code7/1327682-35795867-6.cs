    private void button1_Click_1(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "XML Files|*.xml";
        if(ofd.ShowDialog()== System.Windows.Forms.DialogResult.OK)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Teacher));
                using (FileStream sr = new FileStream(ofd.FileName, FileMode.Open))
                {
                    var teacher = xs.Deserialize(sr) as Teacher;
                    tNametxtBox.Text = teacher.Name1;
                    tIDtxtBox.Text = teacher.ID1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
