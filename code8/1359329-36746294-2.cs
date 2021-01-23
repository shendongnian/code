      protected override void OnFormClosing(FormClosingEventArgs e)
        {
        State state = new State(){Listbox1Choise = (ListboxChoises)System.Enum.Parse(typeof(ListboxChoises),  listView1.SelectedItems[0].SubItems[0].Text);
    
        Stream TestFileStream = File.Create(FileName);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(TestFileStream, state);
        TestFileStream.Close();    
    
        base.OnFormClosing(e);               
        }
