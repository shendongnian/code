    [XmlElement("PenColor")]
    public int penColor { get; set; }
    [XmlElement("PenWidth")]
    public float penWidth  { get; set; }
    public Pen CreatePen()
    {
        return new Pen(Color.FromArgb(penColor), penWidth);
    }
