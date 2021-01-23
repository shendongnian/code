    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Mvc;
    using Kendo.Mvc.UI.Fluent;
    
    namespace WebInterface.Core.Extension
    {
        /// <summary>
        /// Erweiterungsmethoden für das KendoGrid
        /// </summary>
        public static class KendoGrid
        {
            /// <summary>
            /// Fügt der Tabelle eine Bindung mit einem Enum zu
            /// </summary>
            /// <typeparam name="TModel">Der Typ des Models</typeparam>
            /// <typeparam name="TEnum">Der Typ der Enumeration</typeparam>
            /// <param name="model">Das Model</param>
            /// <param name="expression">Die Expression</param>
            public static void Bound<TModel, TEnum>(this GridColumnFactory<TModel> model, Expression<Func<TModel, byte?>> expression)
                where TModel : class
                where TEnum : struct, IComparable, IFormattable, IConvertible
            {
                //Sicherstellen, dass es sich um einen Enum handelt
                if (!typeof(TEnum).IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type");
                }
    
                //Die einzelnen Werte des Enums extrahieren
                var values = (TEnum[])System.Enum.GetValues(typeof(TEnum));
    
                //Eine Zuweisungsliste von Wert und Anzeigenamen erstellen
                var selectList = new SelectList(values.Select(value => new
                {
                    value = Convert.ToInt32(value),
                    displayName =
                        value.GetType()
                            .GetMember(value.ToString(CultureInfo.InvariantCulture))
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .Name
                }), "value", "displayName");
    
                //Fügt die Spalte hinzu
                model.ForeignKey(expression, selectList);
            }
        }
    }
