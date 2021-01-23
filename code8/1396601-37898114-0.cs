                StatePanel[] panels = groupBx.Controls.OfType<StatePanel>().ToArray();
                foreach (StatePanel sp1 in panels)
                {
                    tabPageRegions.Controls.Add(sp1);
                    sp1.Location = new Point(sp1.OrigXPosition, sp1.OrigYPosition);
                }
