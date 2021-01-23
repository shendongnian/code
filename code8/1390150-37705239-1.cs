      public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string error = string.Format("Message: {0}, InnerException: {1}",
                                     ex.Message,
                                     (ex.InnerException != null ? ex.InnerException.ToString() : "")
                                     );
                throw new Exception("DbUpdateException: " + error);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                string error = string.Format("Message: {0}, InnerException: {1}",
                                   ex.Message,
                                   (ex.InnerException != null ? ex.InnerException.ToString() : "")
                                   );
                throw new Exception("UpdateException: " + error);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string error = string.Format("Message: {0}, InnerException: {1}, SqlErrorNumber: {2}, StackTrace: {3}",
                    ex.Message,
                    (ex.InnerException != null ? ex.InnerException.Message : ""),
                    ex.Number.ToString(),
                    ex.StackTrace.ToString()
                    );
                throw new Exception("SqlException: " + error);
            }
            catch
            {
                throw;
            }
        }
