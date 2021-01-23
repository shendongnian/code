    UserData uData = new UserData();
    foreach (object i in comboBox1.Items) // Change name of ComboBox if necessary.
    {
        uData.Data.Add(i.ToString());
    }
    XmlSerializer xs = new XmlSerializer(typeof(UserData));
    using (FileStream fs = new FileStream("userData.xml", FileMode.OpenOrCreate)) // Change path accordingly.
    {
        xs.Serialize(fs, uData);
    }
