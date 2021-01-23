    class WorkItem
    {
        private ICollection<ItemUsage> _usage;
    
        public virtual ICollection<ItemUsage> Usage
        {
            get { return _usage ?? (_usage = new Collection<ItemUsage>()); }
        }
    }
