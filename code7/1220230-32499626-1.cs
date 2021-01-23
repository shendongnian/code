    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.SharePoint;
    
    namespace Code_Generation {
    	/// <summary>
    	/// Generates List object entities from a site connection.
    	/// </summary>
    	public class SPListPocoGenerator {
    		string parentDir = "GeneratedListPOCO/";
    		string hiddenDir = "GeneratedListPOCO/HiddenLists/";
    
    		private class PropertyString {
    			private string _propStr;
    
    			public PropertyString(string propStr) {
    				_propStr = propStr;
    				_properties = new Dictionary < string, string > ();
    			}
    
    			private Dictionary < string, string > _properties;
    			public string this[string key] {
    				get {
    					return _properties.ContainsKey(key) ? _properties[key] : string.Empty;
    				}
    				set {
    					if (_properties.ContainsKey(key)) {
    						_properties[key] = value;
    					} else {
    						_properties.Add(key, value);
    					}
    				}
    			}
    
    
    
    			/// <summary>
    			/// Replaces properties in the format {{propertyName}} in the source string with values from KeyValuePairPropertiesDictionarysupplied dictionary.nce you've set a property it's replaced in the string and you 
    			/// </summary>
    			/// <param name="originalStr"></param>
    			/// <param name="keyValuePairPropertiesDictionary"></param>
    			/// <returns></returns>
    			public override string ToString() {
    				string modifiedStr = _propStr;
    				foreach(var keyvaluePair in _properties) {
    					modifiedStr = modifiedStr.Replace("{{" + keyvaluePair.Key + "}}", keyvaluePair.Value);
    				}
    
    				return modifiedStr;
    			}
    		}
    
    
    
    		public string _classDefinitionStr = @
    		"
    using System;
    using Microsoft.SharePoint;
    
    public class {{EntityName}}
    {
        private SPListItem listItem;
        public {{EntityName}}_InternalProperties InternalProperties
        {
            get; private set;
        }
    
        public {{EntityName}}(SPListItem li)
        {
            this.listItem = li;
            this.InternalProperties = new {{EntityName}}_InternalProperties(this.listItem);
        }
    
        {{PropertySections}}   
        public class {{EntityName}}_InternalProperties
        {
            private SPListItem listItem;
    
            public {{EntityName}}_InternalProperties(SPListItem li)
            {
                this.listItem = li;
            }
            
            {{HiddenPropertySections}}
            {{InternalPropertySections}}  
        }     
    }";
    
    		private const string _propertySectionStr = "\n\n\t" + @
    		"public {{PropertyType}} {{PropertyName}}
        {   get { return listItem[Guid.Parse("
    		"{{PropertyId}}"
    		")] as {{PropertyType}}; }
            set { listItem[Guid.Parse("
    		"{{PropertyId}}"
    		")] = value; }}";
    
    		/// <summary>
    		/// Gets string identifying the field type
    		/// </summary>
    		/// <param name="field"></param>
    		/// <returns></returns>
    		private string GetSafeTypeName(SPField field) {
    			if (field.FieldValueType == null) {
    				return "object"; //Not going to try to parse it further, this is enough.
    			}
    
    			var type = field.FieldValueType;
    
    			if (type.IsValueType) {
    				return type.FullName + "?";
    			}
    			return type.FullName;
    		}
    
    		public void GenerateForWeb(SPWeb web) {
    			var blackList = new[] {
    				"Documents", "Form Templates", "Site Assets", "Site Pages", "Style Library"
    			};
    
    			Directory.CreateDirectory(parentDir);
    			Directory.CreateDirectory(hiddenDir);
    
    			foreach(SPList list in web.Lists) {
    				PropertyString _classDefinition = new PropertyString(_classDefinitionStr);
    
    				string entityName = "SPL_" + list.Title.Replace(" ", "");
    				_classDefinition["EntityName"] = entityName;
    
    				foreach(SPField field in list.Fields) {
    					PropertyString propertySection = new PropertyString(_propertySectionStr);
    
    					propertySection["PropertyType"] = GetSafeTypeName(field); //field.FieldValueType.FullName; -> Returning Null often. Thanks, SharePoint!
    					propertySection["PropertyName"] = field.EntityPropertyName.Replace("_x0020_", "_");
    					propertySection["PropertyId"] = field.Id.ToString();
    
    					if (SPBuiltInFieldId.Contains(field.Id)) _classDefinition["InternalPropertySections"] += propertySection;
    					else if (field.Hidden) _classDefinition["HiddenPropertySections"] += propertySection;
    					else _classDefinition["PropertySections"] += propertySection;
    				}
    
    				if (list.Hidden || blackList.Contains(list.Title)) {
    					File.WriteAllText(hiddenDir + entityName + ".cs", _classDefinition.ToString());
    				} else {
    					File.WriteAllText(parentDir + entityName + ".cs", _classDefinition.ToString());
    				}
    			}
    
    
    
    		}
    
    	}
    
    
    }
