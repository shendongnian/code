        private Size _finalSize;
        protected override Size MeasureOverride(Size availableSize)
        {
            Debug.WriteLine(string.Format("Mesure:{0},{1}", availableSize.Width, availableSize.Height));
            Size desiredSize = base.MeasureOverride(availableSize);
            _finalSize = availableSize;
            return desiredSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            Debug.WriteLine(string.Format("Arrange:{0},{1}", _finalSize.Width, _finalSize.Height));
            base.ArrangeOverride(_finalSize);
            return _finalSize;
        }
