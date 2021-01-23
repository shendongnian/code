    private static void AddAnchorableDocument(DockingManager regionTarget, NotifyCollectionChangedEventArgs e)
            {
                foreach (FrameworkElement element in e.NewItems)
                {
                    var view = element as UIElement;
                    var documentPane = regionTarget.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
    
                    if ((view == null) || (documentPane == null))
                    {
                        continue;
                    }
                    var newContentPane = new LayoutAnchorable
                                             {
                                                 Content = view,
                                                 Title = element.ToolTip.ToString(),
                                                 CanHide = true,
                                                 CanClose = false
                                             };
    
                    DockinWindowChildObjectDictionary.Add(element.ToolTip.ToString(),** newContentPane);
                    documentPane.Children.Add(newContentPane);
                }
            }
