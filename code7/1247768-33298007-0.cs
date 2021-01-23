    var v = dc.BooksDatas.Where(a=> a.BookStatus.Equals("I") && a.BookID.Equals(deposit.BookID) && deposit.DueDate<=DateTime.Today).FirstOrDefault();
                if(v!=null)
                 {
                    v.BookStatus="A";
                    deposit.depositDate = DateTime.Today;
                 }
                UpdateModel(dc.BooksDatas);
                UpdateModel(dc.BookDepositIssues);
                dc.SaveChanges();
