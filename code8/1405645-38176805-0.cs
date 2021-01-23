    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.DirectoryServices.ActiveDirectory;
    using System.Collections;
    namespace AD
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectorySearcher deSearch = new DirectorySearcher();
            ActiveDirectorySchema currSchema = ActiveDirectorySchema.GetCurrentSchema();
            ActiveDirectorySchemaClass collection = currSchema.FindClass("user");
            ReadOnlyActiveDirectorySchemaPropertyCollection properties = collection.GetAllProperties();
            IEnumerator enumerator = properties.GetEnumerator();
            while (enumerator.MoveNext())
            {
                try
                {
                    deSearch.PropertiesToLoad.Add(enumerator.Current.ToString());
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
