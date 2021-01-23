                List<PCProjectItem> projectItems = new List<PCProjectItem>();
                List<UserCostingItem> userCostingItems = new List<UserCostingItem>();
                List<UserCostingItemType> userCostingItemTypes = new List<UserCostingItemType>();
                projectItems = PCProjectItem.GetProjectItems(projectID, sageDatabaseID, PCIntegrationOption);
                userCostingItems = UserCostingItem.GetUserCostingItems(userID, sageDatabaseID, documentType == null ? string.Empty : documentType.Value.ToString());
                userCostingItemTypes = UserCostingItemType.GetUserCostingItemTypes(userID, sageDatabaseID);
                //If there are no project items or allocations, return a new list now
                if (projectItems.Count == 0 || (userCostingItems.Count == 0 && userCostingItemTypes.Count == 0))
                {
                    return new List<PCProjectItem>();
                }
                return (from PCProjectItem projectItem in projectItems
                        join UserCostingItem userCostingItem in userCostingItems on projectItem.PCCostItemID equals userCostingItem.CostingItemID into costingItemJoin
                        join UserCostingItemType userCostingItemType in userCostingItemTypes on projectItem.PCCostItemTypeID equals userCostingItemType.CostingItemTypeID into costingItemTypeJoin
                        where
                        costingItemJoin.DefaultIfEmpty() != null || costingItemTypeJoin.DefaultIfEmpty() != null
                        select projectItem)
                        .Distinct()
                        .ToList();
