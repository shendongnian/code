    foreach (var b in books) {
        var s = b.Element("Subject");
        listBox1.Items.Add(s.Element("Subject1").Value.Trim());
        listBox1.Items.Add(s.Element("Subject1").Value.Trim());
    }
