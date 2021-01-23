    string input = File.ReadAllText("C:\\Public\\input.json");
    dynamic collection = JsonConvert.DeserializeObject(input);
    foreach (var dataItem in collection.data)
    {
        dynamic comments = dataItem.comments;
        foreach (dynamic comment in comments.data)
        {
            string text = comment.text;
        }
    }
