        [Export]
        public class FlyoutsControlRegionAdapter : RegionAdapterBase<FlyoutsControl>
        {
            [ImportingConstructor]
            public FlyoutsControlRegionAdapter(IRegionBehaviorFactory factory)
                : base(factory)
            {
            }
    
            protected override void Adapt(IRegion region, FlyoutsControl regionTarget)
            {
                region.ActiveViews.CollectionChanged += (s, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            Flyout flyout = new Flyout();
                            flyout.Content = element;
                            flyout.DataContext = element.DataContext;
                            regionTarget.Items.Add(flyout);
                        }
                    }
                };
            }
    
            protected override IRegion CreateRegion()
            {
                return new AllActiveRegion();
            }
        }
    
    **Inside Bootstrapper**
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(FlyoutsControl), Container.GetExportedValue<FlyoutsControlRegionAdapter>());
            return mappings;
        }
