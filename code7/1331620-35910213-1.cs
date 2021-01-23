    protected override void OnPaint (PaintEventArgs e)
    {
        base.OnPaint(e);
        var words = new Dictionary<string, decimal> {
            { "Programming", 1345.25M },
            { "Program", 54.25M },
            { "C#", 342325.25M }
        }.ToArray();
            
        var g = e.Graphics;
        var font = button1.Font;
        var maxWidth = words.Max(x => g.MeasureString($"{x.Key}{x.Value}", font).Width);
        SetButtonText(g, maxWidth, button1, words[0]);
        SetButtonText(g, maxWidth, button2, words[1]);
        SetButtonText(g, maxWidth, button3, words[2]);
    }
    private void SetButtonText(Graphics g, 
       float maxWidth, Button button, KeyValuePair<string, decimal> data)
    {
        var minSpacesCount = 5;
        var spaceWidth = g.MeasureString(" ", button.Font).Width;
        var initialTextWidth = g.MeasureString($"{data.Key}{data.Value}", button.Font).Width;
        var spacesToAdd = minSpacesCount + (int)((maxWidth - initialTextWidth) / spaceWidth);
        button.Text = $"{data.Key}{new String(' ', spacesToAdd)}{data.Value}";
    }
