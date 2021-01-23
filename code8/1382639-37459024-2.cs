      var filteredCustomers =
                  from condition in f
                  from custmer in c
                  from product in custmer.Product
                  let propertyName = condition.propertyName
                  let propertyValue = condition.propertyValue
                  where (nameof(custmer.FirstName) == propertyName && custmer.FirstName == propertyValue)
                        &&
                        (condition.Conditions.Any(p => p.propertyName == nameof(product.ProductColor))
                        && condition.Conditions.Any(p => p.propertyValue == product.ProductNumber))
                  select custmer;
    
                foreach (var filterCustmer in filteredCustomers.Distinct())
                {
                    Console.WriteLine(filterCustmer.FirstName);
                }
