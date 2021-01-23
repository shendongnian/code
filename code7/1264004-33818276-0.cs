    using System;
    using CMS.Base;
    using CMS.MacroEngine;
    using CMS.Helpers;
    using CMS.CustomTables;
    //declare CustomMacroNamespace
    [Extension(typeof(CustomMacroMethods))]
    public class CustomMacroNamespace : MacroNamespace<CustomMacroNamespace>
    {
    }
    //register CustomMacroNamespace into the macro engine
    [MacroNamespaceLoader]
    public partial class CMSModuleLoader
    {
       /// <summary>
       /// Attribute class that ensures the registration of custom macro namespaces.
       /// </summary>
       private class MacroNamespaceLoaderAttribute : CMSLoaderAttribute
       {
          /// <summary>
          /// Called automatically when the application starts.
          /// </summary>
          public override void Init()
          {
             // Registers "CustomNamespace" into the macro engine
              MacroContext.GlobalResolver.SetNamedSourceData("CustomMacroNamespace", CustomMacroNamespace.Instance);
          }
       }
    }
    //declare custom macro methods
    public class CustomMacroMethods : MacroMethodContainer
    {
       [MacroMethod(typeof(object), "Returns the Value of a Column in a Custom Table as an object.", 3)]
       [MacroMethodParam(0, "CustomTableCodeName", typeof(string), "The Custom Table code name. Eg customtable.TableName")]
       [MacroMethodParam(1, "CustomTableItemID", typeof(int), "The ID of the to return.")]    
       [MacroMethodParam(2, "CustomTableReturnColumnName", typeof(string), "The field name of the column containing the value to return")]
       public static object GetCustomTableValue(EvaluationContext context, params object[] parameters)
      {
        if (parameters.Length == 3)
        {
            string customTableCodeName = ValidationHelper.GetString(parameters[0], "");
            int customTableID = ValidationHelper.GetInteger(parameters[1], -1);
            string customTableReturnFieldName = ValidationHelper.GetString(parameters[2], "");
            CustomTableItem cti = CustomTableItemProvider.GetItem(customTableID, customTableCodeName);
            if (cti != null)
            {
                return cti.GetValue(customTableReturnFieldName);
            }
            else
            {
                return null;
            }
        }
        else
        {
            throw new NotSupportedException("Custom macro GetCustomTableValue() requires three parameters");
        }
      }
    
    }
