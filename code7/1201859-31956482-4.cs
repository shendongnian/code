    public class CustomCheckedColumnFilterPopup : CheckedColumnFilterPopup
    {
        public CustomCheckedColumnFilterPopup(ColumnView view, GridColumn column, Control owner, object creator)
            : base(view, column, owner, creator) { }
        public override void Show(Rectangle ownerBounds)
        {
            string filterString = Column.FilterInfo.FilterString;
            if (!string.IsNullOrEmpty(filterString))
                Item.FilterValues =
                    string.Join("\n",
                        from item in Item.Items.OfType<CheckedListBoxItem>()
                        let itemValue = (string)item.Value
                        where itemValue != null && filterString.Contains("Contains([" + Column.FieldName + "], '" + item.Value + "'")
                        select itemValue);
            base.Show(ownerBounds);
        }
    }
