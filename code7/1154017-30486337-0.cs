    /// <copyright file="HtmlAttributes.cs"><author username="Octopoid">Chris Bellini</author></copyright>
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Web.Mvc;
    public class HtmlAttributes : Dictionary<string, object>
    {
        public HtmlAttributes()
            : base()
        {
        }
        public HtmlAttributes(object anonymousAttributes)
            : base(HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousAttributes))
        {
        }
        public HtmlAttributes(IDictionary<string, object> attributes)
            : base(attributes)
        {
        }
        public void Add(object anonymousAttributes)
        {
            this.Add(HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousAttributes));
        }
        public void Add(IDictionary<string, object> attributes)
        {
            foreach (var attribute in attributes)
            {
                this.Add(attribute.Key, attribute.Value);
            }
        }
        public void AddCssClass(string cssClass)
        {
            if (cssClass == null) { throw new ArgumentNullException("cssClass"); }
            string key = "class";
            if (this.ContainsKey(key))
            {
                string currentValue;
                if (this.TryGetString(key, out currentValue))
                {
                    this[key] = currentValue + " " + cssClass;
                    return;
                }
            }
            this[key] = cssClass;
        }
        public void Remove(object anonymousAttributes)
        {
            this.Remove(HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousAttributes));
        }
        /// <summary>
        /// Removes the value with the specified key from the <see cref="System.Collections.Generic.Dictionary<TKey,TValue>"/>.
        /// This method hides the base implementation, then calls it explicity.
        /// This is required to prevent the this.Remove(object) method catching base.Remove(string) calls.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        /// true if the element is successfully found and removed; otherwise, false.
        /// This method returns false if key is not found in the System.Collections.Generic.Dictionary<TKey,TValue>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        public new bool Remove(string key)
        {
            return base.Remove(key);
        }
        public void Remove(IDictionary<string, object> attributes)
        {
            foreach (var attribute in attributes)
            {
                this.Remove(attribute.Key);
            }
        }
        public MvcHtmlString ToMvcHtmlString()
        {
            return new MvcHtmlString(this.ToString());
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var item in this)
            {
                output.Append(string.Format("{0}=\"{1}\" ", item.Key.Replace('_', '-'), item.Value.ToString()));
            }
            return output.ToString().Trim();
        }
        public bool TryGetString(string key, out string value)
        {
            object obj;
            if (this.TryGetValue(key, out obj))
            {
                value = obj.ToString();
                return true;
            }
            value = default(string);
            return false;
        }
    }
