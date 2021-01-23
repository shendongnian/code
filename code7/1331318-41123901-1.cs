       public partial class ExpandableView: ContentView
        {
    
            private TapGestureRecognizer _tapRecogniser;
            private StackLayout _summary;
            private StackLayout _details;
    
            public ExpandableView()
            {
                InitializeComponent();
                InitializeGuestureRecognizer();
                SubscribeToGuestureHandler();    
            }
    
            private void InitializeGuestureRecognizer()
            {
                _tapRecogniser= new TapGestureRecognizer();
                SummaryRegion.GestureRecognizers.Add(_tapRecogniser);
            }
    
            private void SubscribeToGuestureHandler()
            {
                _tapRecogniser.Tapped += TapRecogniser_Tapped;
            }
    
            public virtual StackLayout Summary
            {
                get { return _summary; }
                set
                {
                    _summary = value;    
                    SummaryRegion.Children.Add(_summary);
                    OnPropertyChanged();
                }
            }
    
            public virtual StackLayout Details
            {
               get { return _details; }
               set 
               {
                  _details = value;
                  DetailsRegion.Children.Add(_details);
                  OnPropertyChanged();
               }
           }
    
           private void TapRecogniser_Tapped(object sender, EventArgs e)
        {
            if (DetailsRegion.IsVisible)
            {
                DetailsRegion.IsVisible = false;
            }
            else
            {
                 DetailsRegion.IsVisible = true;
            }
        }
