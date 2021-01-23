    string[] songList = System.IO.File.ReadAllLines(@"songlist.txt");
    for (int i = 0; i < songList.Length; i++) {
         string newItem = ((i+1).ToString()) + " " + songList[i];
         combo1.Items.Add(newItem);
    }
