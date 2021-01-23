     @foreach (var **controle** in Model.product)
            {<tr>
                @foreach (XElement control in childList.Descendants("Control"))
                {
                 
                    switch (@control.Attribute("type").Value)
                    {
                        case "Text":
                            // Use the text block below to separate html elements from code
                            string HelpNote = control.Elements("HelpNote").FirstOrDefault().Value;
                            string value = control.Elements("BoundField").FirstOrDefault().Value;                           
                            var vrednost = **controle**.GetType().GetProperty(value).GetValue(**controle**, null);   
