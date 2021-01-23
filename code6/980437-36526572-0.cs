    public class EnumTemplateColumn : DataGridBoundColumn
    {
        private readonly Type enumType;
        public EnumTemplateColumn(Type enumType)
        {
            this.enumType = enumType;
        }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            string columnHeader = cell.Column.Header.ToString();
            TextBlock textBlock = new TextBlock();
            var dataRowView = (DataRowView) dataItem;
            var enumValue = dataRowView[columnHeader];
            textBlock.Text = Enum.GetName(this.enumType, enumValue);
            return textBlock;
        }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            throw new NotImplementedException();
        }
    }
