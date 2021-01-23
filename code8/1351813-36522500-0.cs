      SizeChanged += (s, e) =>
            {
                WellCanvas.SetCoordinateSystem(wm.OverallStartDepth,
                                                wm.OverallEndDepth,
                                                wm.OverallEndDepth,
                                                wm.OverallStartDepth);
                **// This seemed to solve the problem**
                foreach (FrameworkElement elem in WellCanvas.Children)
                    elem.InvalidateVisual();
            };
