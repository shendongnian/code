    public class DynamicDataRow : DynamicObject
    {
        private DataRow _dataRow;
     
        public DynamicDataRow(DataRow dataRow)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            this._dataRow = dataRow;
        }
     
        public DataRow DataRow
        {
            get { return _dataRow; }
        }
     
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (_dataRow.Table.Columns.Contains(binder.Name))
            {
                result = _dataRow[binder.Name];
                return true;
            }
            return false;
        }
     
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_dataRow.Table.Columns.Contains(binder.Name))
            {
                _dataRow[binder.Name] = value;
                return true;
            }
            return false;
        }
    }
