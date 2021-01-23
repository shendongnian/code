        public void SaveToFile()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<UserData>));
			using (var sw = new StreamWriter("output.txt"))
			{
				serializer.Serialize(sw, UserDataCollection);
				sw.Close();
			}
		}
		public void LoadFromFile()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<UserData>));
			using (Stream reader = new FileStream("output.txt", FileMode.Open))
			{
				// Call the Deserialize method to restore the object's state.
				UserDataCollection = (ObservableCollection<UserData>)serializer.Deserialize(reader);
			}
		}
