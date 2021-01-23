           List<Item> result = (from dishes in Dish
                                 join components in Component on dishes.DishID equals components.DishID into item
                                 from p in item.DefaultIfEmpty()
								 where ((p != null) && (p.ComponentID > 0))
                                 select new 
								 	{ 
										CategoryID = dishes.CategoryID, 
										DishID = dishes.DishID, 
										ComponentID = p != null ? p.ComponentID : default(int), 
										DishName = dishes.DishName,
										AmountID = p != null ? p.AmountID : null, 
										NameID = p != null ? p.NameID : null 
									})
								   .ToList()
								   .GroupBy(key => key.DishID)
                                   .Select(g => new Item()
                                   {
                                       DishID = g.Key,
                                       components = g.Select(t => new Component 
									   								{ 
																		AmountID = t.AmountID, 
																		ComponentID = t.ComponentID, 
																		DishID = t.DishID,
																		NameID = t.NameID 
																	})
													  .ToList()
                                   })
                                   .ToList();
