    [XmlIgnore]
    public Pen pen { get; set; }
    [XmlElement("PenColor")]
    public int penColor
    {
        get { return pen.Color.ToArgb(); }
        set { pen = new Pen(Color.FromArgb(value), pen.Width); }
    }
    [XmlElement("PenWidth")]
    public float penWidth
    {
        get { return pen.Width; }
        set { pen = new Pen(pen.Color, value); }
    }
