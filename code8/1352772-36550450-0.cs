    var text = Text.ToList();
    foreach (var i in Indexes)
    {
        if (i < text.Count)
            text.RemoveAt(i);
    }
    Text = text.ToString();
