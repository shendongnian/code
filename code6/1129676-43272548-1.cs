            if (!isDraggingDocuments)
            {
                _areas.Add(new DropArea<DockingManager>(
                    this,
                    DropAreaType.DockingManager));
                foreach (var areaHost in this.FindVisualChildren<LayoutAnchorablePaneControl>())
                {
                    if (areaHost.Model.Descendents().Any())
                    {
                        _areas.Add(new DropArea<LayoutAnchorablePaneControl>(
                            areaHost,
                            DropAreaType.AnchorablePane));
                    }
                }
            }
            // -----> This else is new
            else
            { 
                foreach (var areaHost in this.FindVisualChildren<LayoutDocumentPaneControl>())
                {
                    _areas.Add(new DropArea<LayoutDocumentPaneControl>(
                        areaHost,
                        DropAreaType.DocumentPane));
                }
                foreach (var areaHost in this.FindVisualChildren<LayoutDocumentPaneGroupControl>())
                {
                    var documentGroupModel = areaHost.Model as LayoutDocumentPaneGroup;
                    if (documentGroupModel.Children.Where(c => c.IsVisible).Count() == 0)
                    {
                        _areas.Add(new DropArea<LayoutDocumentPaneGroupControl>(
                            areaHost,
                            DropAreaType.DocumentPaneGroup));
                    }
                }
            }
            return _areas;
