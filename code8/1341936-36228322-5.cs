    public IEnumerable<BaseClass> AllIsSelected(BaseClass root)
        {
            if (root.IsSelected)
            {
                yield return root;
            }
            var composite = root as DerivedOne;
            if (composite != null)
            {
                foreach (var x in composite.Children.SelectMany(v => AllIsSelected(v)))
                {
                    yield return x;
                }
            }
        }
