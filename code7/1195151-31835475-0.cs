        public static IEnumerable<CalculateToAmount> GetCalculateToAmounts(this IQueryable<Item> entityItems, decimal percentage)
        {
            var func = CalculateAmountExpression(percentage).Compile();
            return entityItems.AsEnumerable().Select(func);
        }
