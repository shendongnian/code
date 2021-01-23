    class SomeClass
    {
        public List<TGroup> ValidateColumnInList<TItem, TGroup>(List<TGroup> GroupExpression) where TGroup: GroupExpression
        {
            List<TGroup> TempGroupExpression = new List<TGroup>();
            var itemProperties = typeof(TItem).GetProperties();
            foreach (var GrpExpression in GroupExpression)
            {
                bool IsContainColumn = itemProperties.Any(column => column.Name == GrpExpression.ExpressionName);
                if (!IsContainColumn)
                {
                    TempGroupExpression.Add(GrpExpression);
                }
            }
            return TempGroupExpression;
        }
    }
    internal class Product
    {
    }
    internal class GroupExpression 
    {
        public string ExpressionName;
    }
