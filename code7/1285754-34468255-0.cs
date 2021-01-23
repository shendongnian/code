    private void SerializeRoll(string filename)
    {
        XmlSerializer rd = new XmlSerializer(typeof(Roll));
    
        // Instantiate Roll, fill it with data.
        Roll oneRoll = new Roll();
        oneRoll.Code = 1;
        oneRoll.Name = "Test Code"; 
    
        TextWriter writer = new StreamWriter(filename);
        ser.Serialize(writer, oneRoll );
        writer.Close();
    }
