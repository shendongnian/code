    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Steps
    {
        readonly ChildCollection<Step> steps;
        public Steps()
        {
            this.steps = new ChildCollection<Step>();
            this.steps.ChildAdded += (s, e) =>
            {
                if (e.Item != null)
                    e.Item.ParentId = null;
            };
        }
        [System.Xml.Serialization.XmlElementAttribute("Step")]
        public Collection<Step> StepList { get { return steps; } }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Step
    {
        readonly ChildCollection<Step> steps;
        public Step()
        {
            this.steps = new ChildCollection<Step>();
            this.steps.ChildAdded += (s, e) =>
            {
                if (e.Item != null)
                    e.Item.ParentId = this.Id;
            };
        }
        [System.Xml.Serialization.XmlElementAttribute("Step")]
        public Collection<Step> StepList { get { return steps; } }
        [System.Xml.Serialization.XmlAttributeAttribute("Name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public string Id { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute("ParentID")]
        public string ParentId { get; set; }
    }
    public class ChildCollectionEventArgs<TChild> : EventArgs
    {
        public readonly TChild Item;
        public ChildCollectionEventArgs(TChild item)
        {
            this.Item = item;
        }
    }
    public class ChildCollection<TChild> : Collection<TChild>
    {
        public event EventHandler<ChildCollectionEventArgs<TChild>> ChildAdded;
        public event EventHandler<ChildCollectionEventArgs<TChild>> ChildRemoved;
        void OnRemoved(TChild item)
        {
            var removed = ChildRemoved;
            if (removed != null)
                removed(this, new ChildCollectionEventArgs<TChild>(item));
        }
        void OnAdded(TChild item)
        {
            var added = ChildAdded;
            if (added != null)
                added(this, new ChildCollectionEventArgs<TChild>(item));
        }
        public ChildCollection() : base() { }
        protected override void ClearItems()
        {
            foreach (var item in this)
                OnRemoved(item);
            base.ClearItems();
        }
        protected override void InsertItem(int index, TChild item)
        {
            OnAdded(item);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            if (index >= 0 && index < Count)
            {
                OnRemoved(this[index]);
            }
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, TChild item)
        {
            OnAdded(item);
            base.SetItem(index, item);
        }
    }
