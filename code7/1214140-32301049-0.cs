    private void OpenButton_Click(object sender, EventArgs e)
    {
        DataTable values = new DataTable();
        values.Columns.Add("Channel");
        values.Columns.Add("Parameter");
        values.Columns.Add("Attribute1");
        values.Columns.Add("Attribute2");
        values.Columns.Add("Attribute3");
        values.Columns.Add("Attribute4");
        string filePath = @"C:/Users/.../test.xml";
        XDocument xDoc = XDocument.Load(filePath);
        var channels = from channel in xDoc.Descendants("Measurement_Data").Elements()
                       select new
                       {
                           ChannelName = channel.Name,
                           Parameters = channel.Elements().Select(a => new
                           {
                               ParameterName = a.Name,
                               Attribute1 = a.Attribute("Attribute1").Value,
                               Attribute2 = a.Attribute("Attribute2").Value,
                               Attribute3 = a.Attribute("Attribute3").Value,
                               Attribute4 = a.Attribute("Attribute4").Value
                           })
                       };
        foreach (var channel in channels)
        {
            foreach (var element in channel.Parameters)
            {
                DataRow row = values.NewRow();
                row["Channel"] = channel.ChannelName;
                row["Parameter"] = element.ParameterName;
                // If attributes are not numbers, parsing will generate error.
                row["Attribute1"] = Double.Parse(element.Attribute1);
                row["Attribute2"] = element.Attribute2;
                row["Attribute3"] = Double.Parse(element.Attribute3);
                row["Attribute4"] = element.Attribute4;
                values.Rows.Add(row);
            }
        }
        dataGridView1.DataSource = values;
    }
