    var result = (from br in _DB_Branches.Goal_Allocation_Branches
                              join pr in _DB_Product.Goal_Allocation_Products on new { br.Product, br.Year } equals new { Product = pr.ProductID, Year = pr.Year }
                              join n in _DB_Notes.Goal_Allocation_Branch_Notes.Where(n=>n.Year==ddlYear) on br.BranchNumber equals n.Branch into Notes
                              where br.Year==ddlYear 
                              && pr.Show== true
                              && br.BranchNumber==ddlBranch 
                              from x in Notes.DefaultIfEmpty()
                              select new BranchNotesViewModel
                              {
                                 Year=x.Year,
                                  BranchNumber=x.Branch,
                                  ProductID=br.Product,
                                  Notes = x.Notes, 
                                 //All other fields needed
                               }
                              ).ToList();
          
