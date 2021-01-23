    class SomeClass
    {
        public void SomeMethod()
        {
            var groupExpressions = new List<GroupExpression>();
            // populate GroupExpressions somehow
            var validatedGroups = ValidateColumnInList<Product, GroupExpression>(groupExpressions);
        }
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
        public JsonResult CreateProduct<TItem, TGroup>(List<TItem> Products, List<TGroup> GroupExpression) where TGroup : GroupExpression
        {
            List<TGroup> InvalidGroupExpression = ValidateColumnInList<TItem, TGroup>(GroupExpression);
            if (InvalidGroupExpression.Count() <= 0)
            {
                string[] Fields = GroupExpression.Select(x => x.ExpressionName).ToArray();
                var LambdaExp = GroupExpressionBuilder.GroupByExpression<TItem>(Fields);
                IEnumerable<TItem> DuplicateProducts = Products.GroupBy(LambdaExp.Compile()).Where(g => g.Skip(1).Any()).SelectMany(g => g).ToList();
                IEnumerable<object> Indices = DuplicateProducts.Select<TItem, object>(x => Products.IndexOf(x)).ToList();
                return Json(new { Success = true, Indices }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //return Json(new { Message = false });
                return Json(new { Success = false, InvalidGroupExpression }, JsonRequestBehavior.AllowGet);
            }
        }
    }
    internal class Product
    {
    }
    internal class GroupExpression 
    {
        public string ExpressionName;
    }
