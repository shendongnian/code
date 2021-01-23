    List<string> proverbs = new List<string>();
    List<string> cleanverbs = new List<string>();
    List<string> noverbs = new List<string>();
    private void button1_Click(object sender, EventArgs e)
    {
        noverbs.AddRange(new[] { "A", "a", "by", "of", "all", "the", "The", 
            "it's", "it", "in", "on", "is", "not", "will", "has", "can", "under" });
        proverbs = File.ReadLines("D:\\proverbs\\proverbs.txt").ToList();
        cleanverbs = proverbs.Select(x => cleanedLine(x)).ToList();
        listBox1.Items.AddRange(proverbs.ToArray());
        listBox2.Items.AddRange(cleanverbs.ToArray());
    }
    string cleanedLine(string line)
    {
        var words = line.Split(' ');
        return String.Join(" ", words.ToList().Except(noverbs) );
    }
    int countHits(string line, List<string> keys)
    {
        var words = line.Split(' ').ToList();
        return keys.Count(x => words.Contains(x));
    }
    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string line = listBox2.SelectedItem.ToString();
        int max = 0;
        foreach (string proverb in cleanverbs)
        {
            var keys = proverb.Split(' ').ToList();
            int count = countHits(line, keys);
            if (count > max && proverb != line)
            {
                max = count;
                Text = proverb + " has " + max + " hits";
            }
        }
    }
