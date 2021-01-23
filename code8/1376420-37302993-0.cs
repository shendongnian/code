    private static readonly DependencyProperty.Register(
                "PointsOfNodes",
                typeof(ObservableCollection<PointOfNode>),
                typeof(MapControl),
                new PropertyMetadata(new ObservableCollection<PointOfNode>()));
            public ObservableCollection<PointOfNode> PointsOfNodes
            {
                get { return (ObservableCollection<PointOfNode>)this.GetValue(PointsOfNodesProperty); }
                set { this.SetValue(PointsOfNodesProperty, value); }
            }
