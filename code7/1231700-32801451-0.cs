     var vctx = new VenueContext();
            using(var dbtransaction = vctx.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    var order = vctx.Orders.Include("Venue").Include("Transactions.MenuItem").FirstOrDefault(x => x.Id == orderid);
                    if (order.StatusId != 1)
                    {
                        return false;
                    }
                    if (status == 3 || status == 4)
                    {
                        vctx = MoneyRepository.AddMoney(order.UserId, order.Total * -1, vctx);
                    }
                    order.StatusId = status;
                    vctx.SaveChanges();
                    dbtransaction.Commit();
                }
                catch (Exception)
                {
                    dbtransaction.Rollback();
                    return false;
                } 
            }
            return true;
        }
