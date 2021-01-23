    using System.Drawing;
    using System.Text.RegularExpressions;
    using Visio = Microsoft.Office.Interop.Visio;
    static Color GetLayerColor(Visio.Layer layer)
    {
        var str = layer
            .CellsC[(short)Visio.VisCellIndices.visLayerColor]
            .ResultStrU[""];
        // case 1: fixed color
        int colorNum;
        if (int.TryParse(str, out colorNum))
        {
            var visioColor = layer.Document.Colors[colorNum];
            return Color.FromArgb(
                visioColor.Red, 
                visioColor.Green, 
                visioColor.Blue);
        }
        // case 2: RGB formula
        var m = Regex.Match(str, @"RGB\((\d+),\s*(\d+),\s*(\d+)\)").Groups;
        return Color.FromArgb(
            int.Parse(m[1].Value), 
            int.Parse(m[2].Value), 
            int.Parse(m[3].Value)
            );
    }
