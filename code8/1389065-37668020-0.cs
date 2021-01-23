    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    namespace Loacal_DataBase
    {
    class Connection
    {
       static string startupPath = System.IO.Directory.GetCurrentDirectory();      
       static readonly string connectString = @"Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFilename=" + startupPath + "\\Local_DB.mdf";
       public SqlConnection connection = new SqlConnection(connectString);
        
    }
    }
