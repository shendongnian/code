    public class EntryFocusBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Completed += Bindable_Completed;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Completed -= Bindable_Completed;
            base.OnDetachingFrom(bindable);
        }
        private void Bindable_Completed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NextFocusElementName))
                return;
            var parent = ((Entry)sender).Parent;
            while (parent != null)
            {
                var nextFocusElement = parent.FindByName<Entry>(NextFocusElementName);
                if (nextFocusElement != null)
                {
                    nextFocusElement.Focus();
                    break;
                }
                else
                {
                    parent = parent.Parent;
                }
            }
        }
        public string NextFocusElementName { get; set; }
    }
