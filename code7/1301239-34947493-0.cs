    public interface ICell
    {
        string Content { get; set; }
        Color TextColor { get; set; }
        Color BackgroundColor { get; set; }
        double FontSize { get; set; }
        FontWeight FontWeight { get; set; }
        TextWrapping TextWrapping { get; set; }
        //HorizontalAlignment HorizontalTextAlignment { get; set; }
        VerticalAlignment VerticalTextAlignment { get; set; }
        string ToolTip { get; set; }
    }
    public class IndexCell : ICell
    {
       public string Content { get; set; }
       public Color TextColor { get; set; }
       public Color BackgroundColor { get; set; }
       public double FontSize { get; set; }
       public FontWeight FontWeight { get; set; }
       public TextWrapping TextWrapping { get; set; }
       public int? HorizontalTextAlignment { get; set; }
       public VerticalAlignment VerticalTextAlignment { get; set; }
       public string ToolTip { get; set; }
    }
