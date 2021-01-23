    public static Teacher Load(Teacher teacher)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Teacher));
        try
        {
			using (var fs = new FileStream(@"D:\xmlFile.xml", FileMode.Open))
			{
			   return (Teacher) fs.Deserialize(sw);
			}
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message); // Have Error, show error info
        }
        return null;
    }
