            int retry = 5;
            try
            {
                // Get new purchase order number from service
                
                Invoice.InvoiceNumber = GetNewPurchaseOrderNumber();
                // Explicit set state as Added
                Invoice.ObjectState = ObjectState.Added;
                _uow.Repository<Invoice>().InsertGraph(Invoice);
                _uow.Save();
            }
            catch (DbUpdateException ex)
            {
                retry--;
                if (null == ex.InnerException) throw;
                var innerException = ex.InnerException.InnerException
                                       as System.Data.SqlClient.SqlException;
                if (innerException != null &&
                       (
                           innerException.Number == 2627 ||
                           innerException.Number == 2601)
                           && retry > 0
                       )
                {
                    // Get new Invoice Number from service
                    Invoice.InvoiceNumber = GetNewPurchaseOrderNumber();
                    _uow.Save();
                }
                else
                {
                    throw;
                }
            }
