	private void button1_Click(object sender, EventArgs e)
	{
		Form2 form2 = new Form2();
		form2.ShowDialog();
		string newitem = form2.textBox1.Text;
		checklistBox1.Items.Add(newitem);
	}
	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		var saveItems = checkedListBox1.Items.OfType<string>().Select((item, index) =>
		{
			var itemChecked = checkedListBox1.GetItemChecked(index);
			return new SaveItem { Text = item, Checked = itemChecked };
		}).ToArray(); ;
		var serializer = new XmlSerializer(typeof(SaveItem[]));
		using (var writeFile = File.OpenWrite("items.xml"))
		{
			serializer.Serialize(writeFile, saveItems);
		}
	}
	public class SaveItem
	{
		public string Text { get; set; }
		public bool Checked { get; set; }
	}
	private void Form1_Load(object sender, EventArgs e)
	{
		if (File.Exists("items.xml"))
		{
			var serializer = new XmlSerializer(typeof(SaveItem[]));
			using (var readFile = File.OpenRead("items.xml"))
			{
				var saveItems = (SaveItem[])serializer.Deserialize(readFile);
				foreach (var saveItem in saveItems)
				{
					checkedListBox1.Items.Add(saveItem.Text, saveItem.Checked);
				}
			}
		}
	}
