    List<Tuple<int, bool, ChannelMessage>> messages = new List<Tuple<int, bool, ChannelMessage>>();
    foreach (var n in track.Notes)
        InsertNote(n.Pitch, n.Velocity, (int)(n.Position * LENGTH_MULTIPLIER), (int)(n.Length * LENGTH_MULTIPLIER), 0, ref messages);
    messages = messages.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
    foreach (var x in messages)
        t.Insert(x.Item1, x.Item3);
