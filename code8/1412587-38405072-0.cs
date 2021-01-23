    var result = items.Where(item => item.Status == 'obso')
                      .Select(item => new{
                             id,
                             ItemStatus,
                             Description,
                             ItemWarrantyID,
                             ReplacementItemID
                    }).Join(items, 
                            itemA => itemA.ReplacementItemID, 
                            itemB => itemB.id,
                            (itemA, itemB) => new {
                                itemA.ReplacementItemID,
                                itemA.ItemStatus,
                                itemA.Description,
                                itemB.ItemWarrantyID,
                                OriginalItemId = itemA.Id
                   });
