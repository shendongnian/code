	var productDirection = productEntries.Select(
						product => new
							{
								Product = product.Key,
								IsIncoming = product.First().antena == 2 && product.Last().antena == 1,
								IsOutgoing = product.First().antena == 1 && product.Last().antena == 2,
								StillInside = product.First().antena == 1
							});
					foreach (var product in productDirection)
					{
						if (product.IsIncoming)
						{
				// handle incoming products
							Console.WriteLine("The product " + product.Product + " is incoming");
						}
						else if (product.IsOutgoing)
						{
							// handle outgoing products
							Console.WriteLine("The product " + product.Product + " is outgoing");
						}
						else if (product.StillInside)
						{
				//handle still inside products
							Console.WriteLine("The product " + product.Product + " is still inside");
						}
						else
						{
				//handle still outside products
							Console.WriteLine("The product " + product.Product + " is still outside");
						}
					}
