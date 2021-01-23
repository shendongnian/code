    public const int NUM_OF_PAGES = 128;
    Label[] PElabels = new Label[NUM_OF_PAGES];
       
    ...
       
    for (int i = 0; i < NUM_OF_PAGES; i++) // initialization
    {
        PElabels[i] = new Label();
        PElabels[i].Content = 0; //Storing your Data as int in object
        PElabels[i].Margin = new Thickness(50 + 80 * (i % 16), 50 + 20 * (i / 16), 0, 0);
        Grid1.Children.Add(PElabels[i]);
    }
        
    ...
        
    
    for (int i = 0; i < NUM_OF_PAGES; i++)
    {
        PElabels[i].Content = (int)PElabels[i].Content + 2; //Storing your new Data
    }
