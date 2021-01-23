    Dictionary<string, decimal> values = new Dictionary<string, decimal>();
                values.Add("Feb", 10);
                values.Add("Mar", 10);
                values.Add("Apr", 10);
                values.Add("Jun", 10);
                values.Add("Jul", 10);
                values.Add("Aug", 10);
                values.Add("Sep", 10);
                values.Add("Oct", 10);
                values.Add("Nov", 10);
                values.Add("Dec", 10);
    
                Decimal total = 0;
                Item Item = new Item();
            total = Item.GetValuesFromDictionary(values);
