    Hashtable emotions;
    void CreateEmotions()
    {
        emotions = new Hashtable(6);
        emotions.Add(":)", new BitmapImage(new Uri("/Resources/name_of_picture1.png", UriKind.Relative)));
        emotions.Add(":(", new BitmapImage(new Uri("/Resources/name_of_picture2.png", UriKind.Relative)));
    }
    void AddEmotions()
    {
        foreach (string emote in emotions.Keys)
        {
            while (TextBoxDisplay1.Text.Contains(emote))
            {
                int ind = TextBoxDisplay1.Text.IndexOf(emote);
                TextBoxDisplay1.Select(ind, emote.Length);
                Clipboard.SetImage(emotions[emote]);
                TextBoxDisplay1.Paste();
            }
        }
    }
