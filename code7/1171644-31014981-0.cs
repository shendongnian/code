    public static readonly DependencyProperty SubscriberLevelProperty =
    			DependencyProperty.Register( "SubLevel", typeof( SubscriberLevel ),
    			typeof( UCSubscriptionLevels ), new FrameworkPropertyMetadata( SubscriberLevel.ALL, FrameworkPropertyMetadataOptions.None, ( S, E ) => {
    				SubscriberLevel NV = ( SubscriberLevel )E.NewValue;
    				UCSubscriptionLevels sender = S as UCSubscriptionLevels;
    				sender.GetAllChildren<CheckBox>( ).ToList( ).ForEach( chk => {
    					chk.Checked -= sender.CheckedChanged;
    					chk.Unchecked -= sender.CheckedChanged;
    					chk.IsChecked = NV.HasFlag( sender.dctChkSL[chk] );
    					chk.Checked += new RoutedEventHandler( sender.CheckedChanged );
    					chk.Unchecked += new RoutedEventHandler( sender.CheckedChanged );
    				} );
    			} ) );
