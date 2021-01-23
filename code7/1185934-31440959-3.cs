     public void LoadFieldColors(StreamReader colorReader)
        {
            while (colorReader.EndOfStream == false)
            {
                //Read the file from your format
                string line = colorReader.ReadLine();
                string[] fieldData = line.Split(',');
                colorSettings.Add(fieldData[0], new FieldColor(Color.FromArgb(int.Parse(fieldData[1])), Color.FromArgb(int.Parse(fieldData[2]))));
            }
        }
