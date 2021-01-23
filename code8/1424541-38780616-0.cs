        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            if (queryOptions.SelectExpand != null)
            {
                foreach (var selectItem in queryOptions.SelectExpand.SelectExpandClause.SelectedItems)
                {
                    var expandedItem = selectItem as ExpandedNavigationSelectItem;
                    if (expandedItem != null)
                    {
                        // get the entitySetName, tableName
                        string entitySetName = expandedItem.NavigationSource.Name;
                       // can go recursive with expandItem.SelectExpandClause in case we have $epxand=A($expand=B)
                    }
                }
            }
            return base.ApplyQuery(queryable, queryOptions);
        }
