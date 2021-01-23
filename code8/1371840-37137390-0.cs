     public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        public AuthorizeRoleAttribute(string role) : base()
        {
            var result = Enum.Parse(typeof(RolesEnum), role);
            int code = result.GetHashCode();
            List<string> list = new List<string>();
            foreach (var item in Enum.GetValues(typeof(RolesEnum)))
            {
                int tmpCode = item.GetHashCode();
                if (tmpCode >= code)
                {
                    list.Add(item.ToString());
                }
            }
            Roles = string.Join(",", list);
        }
    }
