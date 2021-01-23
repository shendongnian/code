    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace demo
    {
        public static class Extensions
        {
            public static DataTable DataTable(this DataGridView sender)
            {
                return ((DataTable)sender.DataSource);
            }
        }
    }
