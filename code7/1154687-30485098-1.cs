            private void MyControl_Loaded(object sender, RoutedEventArgs e)
            {
                var descriptor = DependencyPropertyDescriptor.FromProperty(FlowDocumentReader.ViewingModeProperty, typeof(FlowDocumentReader));
                descriptor.AddValueChanged(mReader, (s, a) => Reader_ViewModeChanged());
                Reader_ViewModeChanged();
            }
    2. In the handler, dig in to find the `ScrollViewer`. It will only be present when the `ViewingMode` is set to `Scroll`:
            private void Reader_ViewModeChanged()
            {
                mScrollViewer = null;
                if (mReader.ViewingMode == FlowDocumentReaderViewingMode.Scroll)
                {
                    var contentHost = mReader.Template.FindName("PART_ContentHost", mReader) as DependencyObject;
                    if (contentHost != null && VisualTreeHelper.GetChildrenCount(contentHost) > 0)
                    {
                        var documentScrollViewer = VisualTreeHelper.GetChild(contentHost, 0) as FlowDocumentScrollViewer;
                        if (documentScrollViewer != null)
                        {
                            documentScrollViewer.ApplyTemplate();
                            mScrollViewer = documentScrollViewer.Template.FindName("PART_ContentHost", documentScrollViewer) as ScrollViewer;
                        }
                    }
                }
            }
    3. Once you have the `ScrollViewer`, you can call [ScrollToBottom][4] on it when desired.
