    private void GetStream(IEnumerable<int> values)
    {
        string stream = new MemoryStream();
        using (var sw = StreamWiter(stream))
        {
            foreach(int i in values)
                sw.WriteLine(i);
        }
    }
