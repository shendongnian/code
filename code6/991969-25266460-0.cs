    public SeriesItem(string Name, Draw.Color color)
    {
        name = Name;
        backgroundColor = color;
        dataFormatString = "{0}%";
        position = LineAndScatterLabelsPosition.Above;
        lineWidth = 1;
        markerBackgroundColor = Draw.Color.Yellow;
        markerType = MarkersType.Circle;
        markerSize = 8;
        markerBorderColor = Draw.Color.Green;
        tooltipBackgroundColor = Draw.Color.White;
        tooltipDataFormatString = "{0}%";
        Items = new List<decimal>();
    }
