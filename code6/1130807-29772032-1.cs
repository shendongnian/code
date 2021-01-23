    public const int NUM_OF_PAGES = 128;
    Label[] PElabels = new Label[NUM_OF_PAGES];
    
    ...
        
    for (int i = 0; i < NUM_OF_PAGES; i++) // initialization
    {
        PEcnt[i] = 0;
        PElabels[i] = new Label();
        PElabels[i].DataContext = 0; //Storing your Data
        Binding PEcntBind = new Binding("DataContext");
        PEcntBind.Source = PElabels[i];
        PElabels[i].SetBinding(Label.ContentProperty, PEcntBind); //Binding to your stored Data
        PElabels[i].Margin = new Thickness(50 + 80 * (i % 16), 50 + 20 * (i / 16), 0, 0);
        Grid1.Children.Add(PElabels[i]);
    }
        
    ...
        
    for (int i = 0; i < NUM_OF_PAGES; i++)
    {
        PEcnt[i] += 2;
        PElabels[i].DataContext = PEcnt[i]; //Storing your new Data
        BindingExpression LabBindEx = (PElabels[i] as FrameworkElement).GetBindingExpression(Label.ContentProperty);
        LabBindEx.UpdateTarget(); //Updating the Bindings
    }
 
