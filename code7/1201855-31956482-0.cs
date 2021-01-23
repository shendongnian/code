    public class CustomGridView : GridView
    {
        protected override CheckedColumnFilterPopup CreateCheckedFilterPopup(GridColumn column, Control ownerControl, object creator)
        {
            if (column.ColumnEdit is RepositoryItemCheckedComboBoxEdit)
                return new CustomCheckedColumnFilterPopup(this, column, ownerControl, creator);
            else
                return base.CreateCheckedFilterPopup(column, ownerControl, creator);
        }
        protected override void ApplyCheckedColumnFilter(GridColumn column, object stringValues, List<object> checkedValues)
        {
            if (column.ColumnEdit is RepositoryItemCheckedComboBoxEdit)
            {
                var groupOperator =
                    new GroupOperator(
                        GroupOperatorType.Or,
                        from checkedValue in checkedValues
                        where checkedValue != null
                        select
                           new FunctionOperator(
                               FunctionOperatorType.Contains,
                               new OperandProperty(column.FieldName),
                               new OperandValue(checkedValue)));
                ColumnFilterInfo filterInfo;
                switch (groupOperator.Operands.Count)
                {
                    case 0:
                        filterInfo = new ColumnFilterInfo();
                        break;
                    case 1:
                        filterInfo = new ColumnFilterInfo(groupOperator.Operands[0]);
                        break;
                    default:
                        filterInfo = new ColumnFilterInfo(groupOperator);
                        break;
                }
                column.FilterInfo = filterInfo;
            }
            else
                base.ApplyCheckedColumnFilter(column, stringValues, checkedValues);
        }
    }
