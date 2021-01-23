    public ICollectionView Measurements
            {
                get { return measurements; }
    
                set { measurements = value; 
    measurements.Filter = new Predicate<object>(SearchCallbackAnalysis);
    }
            }
