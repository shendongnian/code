    public static Teacher Load()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "XML Files|*.xml";
        if(ofd.ShowDialog()== System.Windows.Forms.DialogResult.OK)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Teacher));
            try
            {
                using (var fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    return (Teacher)fs.Deserialize(sw);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Have Error, show error info
            }
        }
        return null;
    }
