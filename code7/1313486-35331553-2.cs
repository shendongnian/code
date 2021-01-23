    public static readonly DependencyProperty SessionCollectionProperty =
            DependencyProperty.Register(  "SessionCollection"
                                        , typeof(Session)
                                        , typeof(CustomSession)
                                        , new PropertyMetadata(new Session())
                                        );
        public Session SessionCollection
        {
            get { return (Session)GetValue(SessionCollectionProperty); }
            set { SetValue(SessionCollectionProperty, value); }
        }
