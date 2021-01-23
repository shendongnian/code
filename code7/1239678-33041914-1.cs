    public class TestClass
    {
        public static string GenerateUniqueName(DashboardModuleCommonSettings dmcs)
        {
            var propInfos = dmcs.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public).Where(
                p => p.GetCustomAttribute<NotRequiredForUniqueNameAttribute>() == null);
            string uniqueName = "";
            foreach (var propInfo in propInfos)
            {
                //Do something with the property info
            }
            return uniqueName;
        }
    }
