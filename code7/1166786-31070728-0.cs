    collection.CollectionChanged += (s, args) =>
                {
                    var scrollViewer = behavior.AssociatedObject.GetFirstDescendantOfType<ScrollViewer>();
                    scrollViewer.UpdateLayout();
                    scrollViewer.Measure(scrollViewer.RenderSize);
                    scrollViewer.ChangeView(0, scrollViewer.ScrollableHeight, scrollViewer.ZoomFactor, false);
                };
