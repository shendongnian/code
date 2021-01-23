    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace xxx.xxx.xxxx.xxx.xxx
    {
        public class xxx
        {
            public static String GetRolesForEntityTSQL(string Entity) {
                return String.Format(@"
                        DECLARE
                               @EntityName VARCHAR(200) = '{0}',
                               @Action VARCHAR(200) = 'Read'
    
                        DECLARE @PrivName VARCHAR(500) = 'prv' + @Action + @EntityName
           
                        SELECT  rb.Name, pb.Name, rb.RoleId, rb.ParentRoleId, rb.ParentRootRoleId
                        FROM   RolePrivilegesBase p
                        INNER JOIN    PrivilegeBase pb
                               ON p.PrivilegeId = pb.PrivilegeId
                               INNER JOIN RoleBase rb
                               ON rb.RoleId = p.RoleId
                        WHERE 
                        pb.Name = @PrivName
    
                        ", Entity);
            }
        }
    }
