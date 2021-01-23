        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Node.Bounds);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                nodeFont = new Font(nodeFont.FontFamily, nodeFont.Size, FontStyle.Bold|FontStyle.Italic);
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black,
                    Rectangle.Inflate(e.Bounds, -2, -2));
            }
            else
            {
                e.DrawDefault = true;
            }
        }
