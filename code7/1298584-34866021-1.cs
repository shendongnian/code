    private DataTemplate GetDataTemplateForTotalPageNumbers(int totalPages)
    {
        var dataTemplate = new DataTemplate();
    
        //set up the label
        var labelFactory = new FrameworkElementFactory(typeof (Label)) {Name = "FooterLabel"};
        labelFactory.SetValue(VisibilityProperty, Visibility.Collapsed);
        labelFactory.SetValue(ContentProperty, new Binding());
    
        dataTemplate.VisualTree = labelFactory;
    
        var dataTrigger = new DataTrigger
        {
            Binding = new Binding("PhysicalPageNumber")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor)
                {
                    AncestorType = typeof (ReportPagePresenter)
                }
            },
            Value = totalPages
        };
    
        dataTrigger.Setters.Add(new Setter {
            TargetName = "FooterLabel",
            Property = VisibilityProperty,
            Value = Visibility.Visible
        });
    
        dataTemplate.Triggers.Add(dataTrigger);
    
        return dataTemplate;
    }
