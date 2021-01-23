    ctx.CustomerInboxes.Where(m => m.CustomerId == customerId &&
                                   m.Reference == item.ShoppingCartWebId.ToString()  &&
                                   m.SubjectId == HerdbookConstants.PendingCartMessage)
                        .AsEnumerable()
                        .Any(c => item.ShoppingCartWebId > (long.TryParse(c.Reference, out t) ? t : long.MaxValue))
