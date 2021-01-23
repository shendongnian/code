    TextReader _textReader = null;
    void MinMaxPosition(UILineRenderer graph)
    {
        bool equals = true;
        if (_textReader == null)
        {
            _textReader = this.GetComponent<TextReader>();
        }
        MaxPosition = _textReader.prices.Max() + _textReader.prices.Max() * 0.0003f;
        MinPosition = _textReader.prices.Min() - _textReader.prices.Min() * 0.0003f;
        print(MaxPosition);
        print(MinPosition);
        for(int i = 0;i<graph.Points.Count();i++)
        {
            if (!Mathf.Approximately( ((graph.Points[i].y / 0.8) * MaxPosition - MinPosition) + MinPosition , _textReader.prices.ElementAt(i)) )
            {
                equals = false;
                break;
            }
        }
        if (_textReader.prices.Count != lastSize || equals == false)
        {
            ReprintGraph(graph);
        }
        lastSize = _textReader.prices.Count;
    }
