    public class ApplicationHelper
    {
          public static string Save(DbContext db)
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Append(db.SaveChanges().ToString() + " changed");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat(@"Entity of type '{0}' in state '{1}' has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        sb.AppendLine();
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendFormat("- Property: '{0}', Error: '{1}'",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
        
                    sb.Append("ERROR: " + sb.ToString());
                }
                catch (DbUpdateException ex)
                {
                    var de = TryDecodeDbUpdateException(ex);
                    if (de == null)
                        throw;
                
                    foreach (var e in de)
                        sb.AppendLine(e.MemberNames + " : " + e.ErrorMessage);
        
                    sb.Append("ERROR: " + sb.ToString());
                }
                catch (Exception ex)
                {
                    sb.Append("ERROR: " + (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
                }
                return sb.ToString();
            }
        
        
            static IEnumerable<ValidationResult> TryDecodeDbUpdateException(DbUpdateException ex)
            {
                if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) ||
                    !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))
                    return null;
                var sqlException =
                    (System.Data.SqlClient.SqlException)ex.InnerException.InnerException;
                var result = new List<ValidationResult>();
                for (int i = 0; i < sqlException.Errors.Count; i++)
                {
                    var errorNum = sqlException.Errors[i].Number;
                    string errorText;
                    if (_sqlErrorTextDict.TryGetValue(errorNum, out errorText))
                        result.Add(new ValidationResult(errorText));
                }
                return result.Any() ? result : null;
            }
