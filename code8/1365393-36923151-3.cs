                long t;
                var initialQuery = ctx.CustomerInboxes.Where(x => m.CustomerId == customerId
                  && m.Reference == item.ShoppingCartWebId.ToString()
                  && m.SubjectId == HerdbookConstants.PendingCartMessage).ToList();
                if (!initialQuery.Any(m => item.ShoppingCartWebId > (long.TryParse(m.Reference, out t) ? t : long.MaxValue)))
                {
                    //do something special
                }
