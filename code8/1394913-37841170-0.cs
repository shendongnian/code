	private void button1_Click(object sender, EventArgs e)
	{
		Form2 form2 = new Form2();
		form2.ShowDialog();
		string newitem = form2.textBox1.Text;
		checklistBox1.Items.Add(newitem);
	}
	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		var saveItems = checklistBox1.Items.OfType<string>().Select((item, index) =>
		{
			var itemChecked = checklistBox1.GetItemChecked(index);
			return Tuple.Create(item, itemChecked);
		});
		var serializer = new XmlSerializer(typeof(Tuple<bool, string>[]));
		using (var writeFile = File.OpenWrite("items.xml"))
		{
			serializer.Serialize(writeFile, saveItems);
		}
	}
	private void Form1_Load(object sender, EventArgs e)
	{
		var serializer = new XmlSerializer(typeof(Tuple<string, bool>[]));
		using (var readFile = File.OpenRead("items.xml"))
		{
			var saveItems = (Tuple<string, bool>[])serializer.Deserialize(readFile);
			foreach (var saveItem in saveItems)
			{
				checklistBox1.Items.Add(saveItem.Item1, saveItem.Item2);
			}
		}
	}
