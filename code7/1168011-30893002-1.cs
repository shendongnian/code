    public static readonly DependencyProperty SearchStringProperty =
        DependencyProperty.Register(
            "SearchString",
            typeof(string),
            typeof(DisplayMailView),
            new UIPropertyMetadata(null, OnSearchStringChanged));
            // This sets OnSearchStringChanged as the PropertyChanged callback
    
    public string SearchString
    {
        get { return (string)GetValue(SearchStringProperty); }
        set
        {
            SetValue(SearchStringProperty, value);
            //  Any code you put here won't be executed 
            // when the DependencyProperty value changes
        }
    }
    private static void OnSearchStringChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        //  This part is not needed, DependencyProperties already
        // notify of their changes automatically
        //if (PropertyChanged != null)
        //{
        //    PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
        //}
        var control = sender as DisplayMailView;     
   
        var loFinds = control.richEditControl1.Document.FindAll(SearchString, SearchOptions.WholeWord);
    
         foreach (var find in loFinds)
         {
             var oDoc = find.BeginUpdateDocument();
             var oChars = oDoc.BeginUpdateCharacters(find);
             oChars.BackColor = System.Drawing.Color.Yellow;
             oDoc.EndUpdateCharacters(oChars);
             find.EndUpdateDocument(oDoc);
         }
    }
