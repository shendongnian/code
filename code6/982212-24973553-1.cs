     using System;
     using System.Windows.Data;
     using System.Collections.Generic;
    namespace Stackoverflow
    {
    public class LocBinding : Binding
    {
        static Dictionary<string, string> localizer=((Dictionary<string,string>)   
         (App.Current.Resources["Localizer"]));
        public LocBinding(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
                throw new ArgumentNullException("binding path is null");
            string value;
            if (localizer.TryGetValue(property, out value))
                this.Source = value;
            else
                throw new KeyNotFoundException(property + "key is not defined in       
                localizer");
        }
    }
    }
