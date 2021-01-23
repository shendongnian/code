    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    
    namespace Login_page.Models
    {
        public class HTMLSelect
        {
            public string id { get; set; }
            public IEnumerable<string> @class { get; set; }
            public string name { get; set; }
            public Boolean required { get; set; }
            public string size { get; set; }
            public IEnumerable<SelectOption> SelectOptions { get; set; }
    
            public HTMLSelect(IEnumerable<SelectOption> options)
            {
    
            }
    
            public HTMLSelect(string id, string name)
            {
                this.id = id;
                this.name = name;
            }
    
            public HTMLSelect(string id, string name, bool required, IEnumerable<SelectOption> options)
            {
                this.id = id;
                this.name = name;
                this.required = required;
            }
    
            private string BuildOpeningTag()
            {
                StringBuilder text = new StringBuilder();
                text.Append("<select");
                text.Append(this.id != null ? " id=" + '"' + this.id + '"' : "");
                text.Append(this.name != null ? " name=" + '"' + this.name + '"' : "");
                text.Append(">");
                return text.ToString();
    
            }
    
            public string GenerateSelect(IEnumerable<SelectOption> options)
            {
                StringBuilder selectElement = new StringBuilder();
                selectElement.Append(this.BuildOpeningTag());
                foreach (SelectOption option in options)
                {
                    StringBuilder text = new StringBuilder();
                    text.Append("\t");
                    text.Append("<option value=" + '"' + option.Value + '"');
                    text.Append(option.Selected != false ? " selected=" + '"' + "selected" + '"' + ">" : ">");
                    text.Append(option.Text);
                    text.Append("</option>");
                    selectElement.Append(text.ToString());
                }
                selectElement.Append("</select");
                return selectElement.ToString();
            }
        }
    
        public class SelectOption
        {
            public string Text { get; set; }
            public Boolean Selected { get; set; }
            public string Value { get; set; }
        }
    }
