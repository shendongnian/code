    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.SharePoint.Client;
    using Field = Microsoft.SharePoint.Client.Field;
    
    namespace SPOClient
    {
        public static class FieldExtensions
        {
    
    
            public static Type GetFieldValueType(this Field field)
            {
                var table = new Dictionary<FieldType, Type>();
                table[FieldType.Guid] = typeof(Guid);
                table[FieldType.Attachments] = typeof(bool);
                table[FieldType.Boolean] = typeof(bool);
                table[FieldType.Choice] = typeof (string);
                table[FieldType.CrossProjectLink] = typeof(bool);
                table[FieldType.DateTime] = typeof(DateTime);
                table[FieldType.Lookup] = typeof(FieldLookupValue);
                table[FieldType.ModStat] = typeof(int);
                table[FieldType.MultiChoice] = typeof(string[]);
                table[FieldType.Number] = typeof(double);
                table[FieldType.Recurrence] = typeof(bool);
                table[FieldType.Text] = typeof(string);
                table[FieldType.URL] = typeof(FieldUrlValue);
                table[FieldType.URL] = typeof(FieldUrlValue);
                table[FieldType.User] = typeof(FieldUserValue);
                table[FieldType.WorkflowStatus] = typeof(int);
                table[FieldType.ContentTypeId] = typeof(ContentTypeId);
                table[FieldType.Note] = typeof(string);
                table[FieldType.Counter] = typeof(int);
                table[FieldType.Computed] = typeof(string);
                table[FieldType.Integer] = typeof(int);
                table[FieldType.File] = typeof(string);
    
                if (!table.ContainsKey(field.FieldTypeKind))
                    throw new NotSupportedException(string.Format("Unknown field type: {0}", field.FieldTypeKind));
                return table[field.FieldTypeKind];
            }
        }
    }
