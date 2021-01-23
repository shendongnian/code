	Dictionary<string, string> dictionary = new Dictionary<string, string>();
	dictionary.Add("ID1", _id1);
	dictionary.Add("ID2", _id2);
	dictionary.Add("ID3", _id3);
	dictionary.Add("ID4", _id4);
	int i = 1;
	foreach (var pair in dictionary)
	{
		if (pair.Value == "True")
		{
			cmd.Parameters.AddWithValue(pair.Key, i.ToString());
		}
		else
		{
			cmd.Parameters.AddWithValue(pair.Key, "0");
		}
		i++;
	}
