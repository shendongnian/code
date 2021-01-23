    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Linq;
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Class1
    {
     public void MethodName()
       {
        var workerRecords = context.tbl_Company_Workers.where(cw =>     w.WorkerRoleID.HasValue && w.WorkerRoleID.Value == 3).ToList();
        }
     }
