    using System;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public static class Extensions
    {
        public static string GetEnumDescription<TEnum>(this TEnum item)
            => item.GetType()
                   .GetField(item.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .Cast<DescriptionAttribute>()
                   .FirstOrDefault()?.Description ?? string.Empty;
    }
