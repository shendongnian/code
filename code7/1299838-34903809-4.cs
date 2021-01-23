    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    
    
    namespace ConsoleApplication1 {
        public class TemplateParser {
    
            private string content;
    
            public TemplateParser(string fileName) {
                Tags = new Dictionary<string, object>();
                //TODO: Add exception control. Perhaps move the reading operation outside the constructor
                content = File.ReadAllText(fileName);
            }
    
            public Dictionary<string, object> Tags { get; private set; }
    
            public void Parse() {
                foreach (string key in Tags.Keys) {
                    if (Tags[key] != null) {
                    object propertyValue;
                    int position = key.IndexOf('.');
                    if (position >= 0) {
                        string propertyName = key.Substring(position + 1);
                        propertyValue = GetPropertyValue(Tags[key], propertyName);
                    } else {
                        propertyValue = Tags[key];
                    }
                    content = content.Replace(string.Concat("{", key, "}"), propertyValue.ToString());
                    } else {
                        //TODO: what to do without not specified replacement?
                    }
                }
            }
    
            public string[] ToArray() {
                return content.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            }
    
    
            private object GetPropertyValue(object obj, string propertyName) {
                PropertyInfo pi = obj.GetType().GetProperties().FirstOrDefault(x => x.Name == propertyName);
                if (pi != null) {
                    return pi.GetValue(obj, null);
                }
                return null;
            }
    
        }
    }
