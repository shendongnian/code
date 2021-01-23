        public class Builder
        {
            private bool hasCarousel = false;
            private int featuredItems = 0;
            
            public Builder WithCarousel()
            {
                hasCarousel = true;
                return this;
            }
                  
            public Builder WithFeaturedItems(int featured)
            {
                featuredItems = featured;
                return this;
            }
            public BuiltObject Build()
            {
                if (hasCarousel)
                {
                    // do carousel related calls
                }
                if (featuredItems > 0)
                {
                    // do featured items related calls.
                }
                // build and return the actual object.
            }
        }
