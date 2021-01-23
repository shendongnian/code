    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    namespace MyNamespace
    {
        class MyPanel : Panel
        {
            int columns;
            int rows;
            protected override Size MeasureOverride (Size constraint)
            {
                Size childConstraint = constraint;
                double maxChildDesiredWidth = 0.0;
                double maxChildDesiredHeight = 0.0;
                if (InternalChildren.Count > 0)
                {
                    for (int i = 0, count = InternalChildren.Count; i < count; ++i)
                    {
                        UIElement child = InternalChildren[i];
                        // Measure the child.
                        child.Measure (childConstraint);
                        Size childDesiredSize = child.DesiredSize;
                        if (maxChildDesiredWidth < childDesiredSize.Width)
                        {
                            maxChildDesiredWidth = childDesiredSize.Width;
                        }
                        if (maxChildDesiredHeight < childDesiredSize.Height)
                        {
                            maxChildDesiredHeight = childDesiredSize.Height;
                        }
                    }
                    columns = (int)(constraint.Width / maxChildDesiredWidth);
                    rows = (int)(InternalChildren.Count / columns + 0.5);
                }
                else
                {
                    columns = 0;
                    rows = 0;
                }
                return new Size ((maxChildDesiredWidth * columns), (maxChildDesiredHeight * rows));
            }
            protected override Size ArrangeOverride (Size arrangeSize)
            {
                Rect childBounds = new Rect (0, 0, arrangeSize.Width / columns, arrangeSize.Height / rows);
                double xStep = childBounds.Width;
                double xBound = arrangeSize.Width - 1.0;
                childBounds.X += 0;
                foreach (UIElement child in InternalChildren)
                {
                    child.Arrange (childBounds);
                    if (child.Visibility != Visibility.Collapsed)
                    {
                        childBounds.X += xStep;
                        if (childBounds.X >= xBound)
                        {
                            childBounds.Y += childBounds.Height;
                            childBounds.X = 0;
                        }
                    }
                }
                return arrangeSize;
            }
        }
    }
