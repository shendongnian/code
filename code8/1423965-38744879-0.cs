    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Models
    {
        public class User
        {
            static private string cdUser;
            static private int cdAcess;
            static private string nmUser;
    
            public static string CdUser
            {
                get
                {
                    return cdUser;
                }
    
                set
                {
                    cdUser = value;
                }
            }
            public static int CdAcess
            {
                get
                {
                    return cdAcess;
                }
    
                set
                {
                    cdAcess = value;
                }
            }
            public static string NmUser
            {
                get
                {
                    return nmUser;
                }
    
                set
                {
                    nmUser = value;
                }
            }
        }
    }
