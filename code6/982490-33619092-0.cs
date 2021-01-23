    public static class ODataQueryOptionsExtensions
    {
        public static List<IEdmType> GetAllExpandedEdmTypes(this ODataQueryOptions self)
        {
            //Define a recursive function here.
            //I chose to do it this way as I didn't want a utility method for this functionality. Break it out at your discretion.
            Action<SelectExpandClause, List<IEdmType>> fillTypesRecursive = null;
            fillTypesRecursive = (selectExpandClause, typeList) =>
            {
                //No clause? Skip.
                if (selectExpandClause == null)
                {
                    return;
                }
                foreach (var selectedItem in selectExpandClause.SelectedItems)
                {
                    //We're only looking for the expanded navigation items, as we are restricting authorization based on the entity as a whole, not it's parts. 
                    var expandItem = (selectedItem as ExpandedNavigationSelectItem);
                    if (expandItem != null)
                    {
                        //https://msdn.microsoft.com/en-us/library/microsoft.data.odata.query.semanticast.expandednavigationselectitem.pathtonavigationproperty(v=vs.113).aspx
                        //The documentation states: "Gets the Path for this expand level. This path includes zero or more type segments followed by exactly one Navigation Property."
                        //Assuming the documentation is correct, we can assume there will always be one NavigationPropertySegment at the end that we can use. 
                        typeList.Add(expandItem.PathToNavigationProperty.OfType<NavigationPropertySegment>().Last().EdmType);
                        //Fill child expansions. If it's null, it will be skipped.
                        fillTypesRecursive(expandItem.SelectAndExpand, typeList);
                    }
                }
            };
            //Fill a list and send it out.
            List<IEdmType> types = new List<IEdmType>();
            fillTypesRecursive(self.SelectExpand.SelectExpandClause, types);
            return types;
        }
    }
