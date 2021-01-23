    // TODO: Build up the whole string, and set the Text property once.
    // Oh, and rename richTextBox1 to something more descriptive.
    foreach (RunePage rune in runePages)
    {
        if (rune.Slots != null)
        {
            var grouped = rune.Slots
                 .GroupBy(slot => slot.RuneId)
                 .Select(group => new { Name = staticApi.GetRune(RiotSharp.Region.lan, 
                                                                 group.Key, RuneData.tags, 
                                                                 Language.es_ES).Name),
                                        Count = group.Count() })
                 .Select(pair => string.Format("{0}x {1}", pair.Count, pair.Name));
            richTextBox1.Text = string.Join("\n", grouped);
        }
        richTextBox1.Text = rune.Name + "\n" + richTextBox1.Text;
    }
