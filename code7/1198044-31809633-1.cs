    using Ninject.Extensions.Conventions.BindingGenerators;
    using Ninject.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    public class CommandBindingGenerator : IBindingGenerator
    {
        private const string CommandSuffix = "Command";
        private const string MenuItemTypeNamePattern = "{0}MenuItem";
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(
            Type type, IBindingRoot bindingRoot)
        {
            string commandName = GetCommandName(type);
            Type menuItem = FindMatchingMenuItem(type.Assembly, commandName);
            var binding = bindingRoot.Bind(typeof(ICommand)).To(type);
 
            // this is a slight hack due to the return type limitation
            // but it works as longs as you dont do Configure(x => .When..)
            binding.WhenInjectedInto(menuItem); 
            yield return binding;
        }
        private static Type FindMatchingMenuItem(
            Assembly assembly, string commandName)
        {
            string expectedMenuItemTypeName = string.Format(
                CultureInfo.InvariantCulture, 
                MenuItemTypeNamePattern,
                commandName);
            Type menuItemType = assembly.GetTypes()
                .SingleOrDefault(x => x.Name == expectedMenuItemTypeName);
            if (menuItemType == null)
            {
                string message = string.Format(
                    CultureInfo.InvariantCulture,
                    "There's no type named '{0}' in assembly {1}",
                    expectedMenuItemTypeName,
                    assembly.FullName);
                throw new InvalidOperationException(message);
            }
            return menuItemType;
        }
        private static string GetCommandName(Type type)
        {
            if (!type.Name.EndsWith(CommandSuffix))
            {
                string message = string.Format(
                    CultureInfo.InvariantCulture,
                    "the command '{0}' does not end with '{1}'",
                    type.FullName,
                    CommandSuffix);
                throw new ArgumentException(message);
            }
            return type.Name.Substring(
                0,
                type.Name.Length - CommandSuffix.Length);
        }
    }
