    using System.IO;
    using System.Xml.Serialization;
    // all drawn curve points are collected here:
    List<List<PointF>> curves = new List<List<PointF>>();
    private void SaveButton_Click(object sender, EventArgs e)
    {
            
        XmlSerializer xmls = new XmlSerializer(typeof(List<List<PointF>>));
        using (Stream writer = new FileStream(yourDrawingFileName, FileMode.Create))
        {
            xmls.Serialize(writer, curves);
            writer.Close();
        }
    }
    private void LoadButton_Click(object sender, EventArgs e)
    {
        if (File.Exists(yourDrawingFileName))
        {
            XmlSerializer xmls = new XmlSerializer(typeof(List<List<PointF>>));
            using (Stream reader = new FileStream(yourDrawingFileName, FileMode.Open))
            {
                var curves_ = xmls.Deserialize(reader);
                reader.Close();
                curves = (List<List<PointF>>) curves_;
                Console.Write(curves.Count + " curves loaded.");
            }
        }
        yourPanelOrPictureBoxOrForm.Invalidate;
    }
