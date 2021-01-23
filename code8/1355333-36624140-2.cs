            this.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(Tests))
                {
                    HasTests = !Tests.Count.Equals(0);
                    //also update when collection changes:
                    Tests.CollectionChanged += (o2, e2) =>
                    {
                        HasTests = !Tests.Count.Equals(0);
                    };
                }
            };
    
