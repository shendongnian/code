    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        public class ResizeGizmo : Thumb
        {
            public ResizeGizmo()
            {
                DragDelta += new DragDeltaEventHandler(this.ResizeGizmo_DragDelta);
            }
    
            private void ResizeGizmo_DragDelta(object sender, DragDeltaEventArgs e)
            {
                float MinSize = 70;
    
                NodeViewModel node = this.DataContext as NodeViewModel;
                var element = sender as FrameworkElement;
    
    
                if (node != null)
                {
                    double deltaVertical, deltaHorizontal;
    
                    switch (VerticalAlignment)
                    {
                        case VerticalAlignment.Bottom:
                            deltaVertical = Math.Min(-e.VerticalChange, node.Height - MinSize);
                            node.Height -= deltaVertical;
                            break;
                        case VerticalAlignment.Top:
                            deltaVertical = Math.Min(e.VerticalChange, node.Height - MinSize);
                            node.Y += deltaVertical;
                            node.Height -= deltaVertical;
                            break;
                        default:
                            break;
                    }
                    switch (HorizontalAlignment)
                    {
                        case HorizontalAlignment.Left:
                            deltaHorizontal = Math.Min(e.HorizontalChange, node.Height - MinSize);
                            node.X += deltaHorizontal;
                            node.Width -= deltaHorizontal;
                            break;
                        case HorizontalAlignment.Right:
                            deltaHorizontal = Math.Min(-e.HorizontalChange, node.Height - MinSize);
                            node.Width -= deltaHorizontal;
                            break;
                        default:
                            break;
                    }
                }
    
                e.Handled = true;
            }
        }
    }
