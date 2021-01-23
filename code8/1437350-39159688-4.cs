    var result = dt.GroupBy(item => new { item.ATTRIBUTE_NAME, item.ATTRIBUTE_DESCRIPT }
                            (key, group) => new 
                            { 
                                key, 
                                Items = group.Select(item => new { item.PARENT_CODE, item.CHILD_COD }).ToList()
                            });
