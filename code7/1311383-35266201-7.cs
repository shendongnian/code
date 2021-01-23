        treeView1.DrawNode += (s, e)
            =>
            {
                if (e.Node.Tag == null || e.Node.Tag.ToString() != "X")
                { e.DrawDefault = true; return; }
                CheckBoxState cbsChDis = CheckBoxState.CheckedDisabled;
                CheckBoxState cbsUCDis = CheckBoxState.UncheckedDisabled;
                Size glyph = Size.Empty;
                glyph = CheckBoxRenderer.GetGlyphSize(e.Graphics, cbsChDis);
                Rectangle tBounds = e.Node.Bounds;  // the real bounds of the hittest area
                if (e.Node.IsSelected)
                {
                    e.Graphics.FillRectangle(SystemBrushes.MenuHighlight, tBounds);
                    e.Graphics.DrawString(e.Node.Text , Font, Brushes.White,
                                            tBounds.X , tBounds.Y);
                }
                else
                {
                    CheckBoxRenderer.DrawParentBackground(e.Graphics, e.Bounds, this);
                    e.Graphics.DrawString(e.Node.Text , Font, Brushes.Black,
                                            tBounds.X , tBounds.Y);
                }
                Point cBoxLocation = new Point(tBounds.Left - glyph.Width , tBounds.Top);
                CheckBoxState bs1 = e.Node.Checked ? cbsChDis : cbsUCDis;
                CheckBoxRenderer.DrawCheckBox(e.Graphics, cBoxLocation, bs1);
            };
 
