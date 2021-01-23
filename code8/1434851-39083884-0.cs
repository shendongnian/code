    public static class OperatorsHelper
    {
        public static IEnumerable<string> StrOperators = new List<string>
        {
            return new[] { "=", "<>", "IN", "NOT IN" }.Select(op => new SelectListItem
            {
                Text = op,
                Value = op
            });
        };
    }
