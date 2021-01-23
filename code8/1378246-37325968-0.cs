     using System.Reflection;
        
        //...
        foreach (string productLine in productLineData)
        {
            string templateKey = "{{" + productLine + "}}";
            string templateValue = string.Empty;
            object value =  productRow.GetType().GetProperty(productLine).GetValue(productRow, null);
            if (value != null)
                templateValue = value.ToString();
            productRowText = productRowText.Replace(templateKey, templateValue);
        }
        //...
        
