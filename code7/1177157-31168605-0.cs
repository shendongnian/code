                var blockGroupsTemp;
                if (showAdvanced) 
                    blockGroupsTemp = blockGroups;
                else
                {
                    blockGroupsTemp = blockGroups.Where(x => x.Advanced == false).ToList();
                    blockGroupsTemp.ForEach(s => s.ChildGroups.RemoveAll(y => y.Advanced == true));
                }
                var mappedViewModels = Mapper.Map<ObservableCollection<ItemFilterBlockGroupViewModel>>(blockGroupsTemp);
