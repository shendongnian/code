    var dictionary = new System.Collections.Specialized.OrderedDictionary();
    dictionary.Add("A", "A Value");
    dictionary.Add("C", "C Value");
    dictionary.Add("D", "D Value");
    MessageBox.Show(dictionary.IndexOf("C").ToString()); //Shoud be 1
    MessageBox.Show(dictionary.IndexOf("B").ToString()); //Shoud be -1
    dictionary.Insert(1, "B", "B Value");
    MessageBox.Show(dictionary.IndexOf("B").ToString()); //Shoud be 1
    MessageBox.Show(dictionary.IndexOf("D").ToString()); //Shoud be 3
