    /// <summary>
    /// Add a button to wrapPanel1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddButton(object sender, RoutedEventArgs e)
    {
        // Create the Button.
        Button button = new Button();
        button.Height = 50;
        button.Width = 100;
        button.Background = Brushes.AliceBlue;
        button.Content = "Click Me";
    
        wrapPanel1.Children.Add(button);
    }
    
    /// <summary>
    /// Save wrapPanel1 to AA.xaml
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveButtons(object sender, RoutedEventArgs e)
    {
        StringBuilder outstr = new StringBuilder();
    
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineOnAttributes = true;
    
    
        XamlDesignerSerializationManager dsm = new XamlDesignerSerializationManager(XmlWriter.Create(outstr, settings));
        dsm.XamlWriterMode = XamlWriterMode.Expression;
    
        XamlWriter.Save(wrapPanel1, dsm);
        string savedControls = outstr.ToString();
    
        File.WriteAllText(@"AA.xaml", savedControls);
    }
    
    /// <summary>
    /// Reload the buttons in AA.xaml
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ReloadButtons(object sender, RoutedEventArgs e)
    {
        StreamReader sR = new StreamReader(@"AA.xaml");
        string text = sR.ReadToEnd();
        sR.Close();
    
        StringReader stringReader = new StringReader(text);
        XmlReader xmlReader = XmlReader.Create(stringReader);
    
        WrapPanel wp = (WrapPanel)System.Windows.Markup.XamlReader.Load(xmlReader);
               
        wrapPanel1.Children.Clear(); // clear the existing children
    
        foreach (FrameworkElement child in wp.Children) // and for each child in the WrapPanel we just loaded (wp)
        {
            wrapPanel1.Children.Add(CloneFrameworkElement(child)); // clone the child and add it to our existing wrap panel
        }           
    }
    
    /// <summary>
    /// Clone a framework element by serializing and deserializing it
    /// </summary>
    /// <param name="originalElement"></param>
    /// <returns></returns>
    FrameworkElement CloneFrameworkElement(FrameworkElement originalElement)
    {
        string elementString = XamlWriter.Save(originalElement);
                
        StringReader stringReader = new StringReader(elementString);
        XmlReader xmlReader = XmlReader.Create(stringReader);
        FrameworkElement clonedElement = (FrameworkElement)XamlReader.Load(xmlReader);
    
        return clonedElement;
    }
