    <Entry Text="{Binding CountText}" WidthRequest="70" Keyboard="Numeric">
        <Entry.Behaviors>
            <local:FocusEntryFromSelectedRowBehavior BindingContext="{x:Reference SkuListView}" />
        </Entry.Behaviors>
    </Entry>
    public class FocusEntryFromSelectedRowBehavior : Behavior<Entry>
    {
        public Entry AssociatedEntry{ get; private set; }
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            AssociatedEntry = entry;            
            ((ListView)BindingContext).ItemSelected += MyView_ItemSelected;           
        }
        private void MyView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            if (AssociatedEntry.BindingContext == e.SelectedItem)
            {
                AssociatedEntry.Focus();
            }
        }
        protected override void OnDetachingFrom(Entry entry)
        {            
            ((ListView)BindingContext).ItemSelected -= MyView_ItemSelected;
            base.OnDetachingFrom(entry);
        }
    }
