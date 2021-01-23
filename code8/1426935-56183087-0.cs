        /// <summary>
        /// Indique si un overlay est présent
        /// </summary>
        public GridLength ItemHeight
        {
           get
           {
              return (GridLength)GetValue(ItemHeightProperty);
           }
           set
           {
              SetValue(ItemHeightProperty, value);
           }
        }
