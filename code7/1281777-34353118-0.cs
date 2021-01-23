    public class OperatorNode : TreeNode
    {
        private OperatorType _operator;
        public OperatorType Operator
        {
            get { return _operator; }
            set
            {
                if(value==_operator) return;
                _operator = value;
                Text = _operator.ToString();
            }
        }
        public OperatorNode(OperatorType @operator) : base(@operator.ToString())
        {
            _operator = @operator;
        }
        public override string ToString()
        {
            List<string> n = (from TreeNode node in Nodes select node.ToString()).ToList();
            return " ( " + string.Join(Environment.NewLine + _operator + " ", n) + " ) ";
        }
    }
    public class SqlTextNode : TreeNode
    {
        private string _fieldName;
        private ContitionType _condition;
        private string _value;
        public SqlTextNode(string fieldName, ContitionType condition, string value)
        {
            _fieldName = fieldName;
            _condition = condition;
            _value = value;
            UpdateText();
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _fieldName, _condition.GetDescription(), _value);
        }
        public string FieldName
        {
            get { return _fieldName; }
            set
            {
                if (value == _fieldName) return;
                _fieldName = value;
                UpdateText();
            }
        }
        public ContitionType Condition
        {
            get { return _condition; }
            set
            {
                if (value == _condition) return;
                _condition = value;
                UpdateText();
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                if (value == _value) return;
                _value = value;
                UpdateText();
            }
        }
        private void UpdateText()
        {
            Text = string.Format("{0} {1} {2}", _fieldName, _condition.GetDescription(), _value);
        }
    }
