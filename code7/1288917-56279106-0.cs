    using System;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.EntityFrameworkCore; //added
    using Microsoft.EntityFrameworkCore.Metadata.Builders; //added
    public static class Extensions
    {
        //unchanged from alberto answer
        public static string GetEnumDescription<TEnum>(this TEnum item)
            => item.GetType()
                   .GetField(item.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .Cast<DescriptionAttribute>()
                   .FirstOrDefault()?.Description ?? string.Empty;
        //changed
        public static void SeedEnumValues<T, TEnum>(this ModelBuilder mb, Func<TEnum, T> converter)
        where T : class => Enum.GetValues(typeof(TEnum))
                               .Cast<object>()
                               .Select(value => converter((TEnum)value))
                               .ToList()
                                .ForEach(instance => mb.Entity<T>().HasData(instance));
    }
