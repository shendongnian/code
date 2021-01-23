        public List<D> getSelectedDs()
        {
            return Bs.SelectMany(b => b.FirstC.Ds.Union(b.SecondC.Ds))
                     .Where(x => x.IsSelected).ToList();
        }
