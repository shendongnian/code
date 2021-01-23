    private void tree_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
        TreeNodeStates state = e.State;
        Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
        Color foreColor;
        Color backColor;
        // node is selected
        // if you want to see the color of a selected node, too,
        // you can use inverted fore/back colors instead of system selection colors 
        if ((state & TreeNodeStates.Selected) == TreeNodeStates.Selected)
        {
            bool isFocused = (state & TreeNodeStates.Focused) == TreeNodeStates.Focused;
            backColor = SystemColors.Highlight;
            foreColor = isFocused ? SystemColors.HighlightText : SystemColors.InactiveCaptionText;
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            if (isFocused)
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, foreColor, backColor);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }
        // node is not selected
        else
        {
            backColor = GetBackColor(e.Node); // todo: GetBackColor
            foreColor = GetForeColor(e.Node); // todo: GetForeColor
            using (Brush background = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(background, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
            }
        }
    }
