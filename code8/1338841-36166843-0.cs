    using System;
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ConfigAuthorizeAttribute : Attribute
    {
        public string RolesConfigurationKey { get; set; }
        public string UsersConfigurationKey { get; set; }
    }
