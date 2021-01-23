    public class MyData
    {
        public string Text; // to save textbox text, could be public field or property
    }
    // to save
    var data = new MyDate() { Text = textBox.Text };
    using (var stream = new FileStream("somefile", FileMode.OpenOrCreate))
    {
        var serializer = new XmlSerializer(data.GetType()); // or typeof(MyData)
        serializer.Serialize(fileStream, data);
    }
    // to load
    using (var stream = new FileStream("somefile", FileMode.Open, FileAccess.Read))
    {
        var serializer = new XmlSerializer(typeof(MyData));
        var data = serializer.Deserialize(stream) as MyData;
        textBox.Text = data.Text;
	}
