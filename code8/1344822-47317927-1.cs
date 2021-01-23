    modelBuilder.Entity<Order>()
                    .MapToStoredProcedures(sp =>
                    {
                        sp.Insert(i => i.HasName("web_DS_Set_DocHeaders")
                                        .Parameter(p => p.OutletID, "mfID")
                                        .Parameter(p => p.DocTypeID, "orType")
                                        .Parameter(p => p.Comment, "orComment")
                                        .Parameter(p => p.Sum, "orSum")
                                        
                                        .Result(r => r.Number, "orNumber")
                                        .Result(r => r.OrderDate,"orDate")
                                        .Result(r => r.ID, "orID"));
                    });
