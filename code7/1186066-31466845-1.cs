    List<CartItem> GetAllCartItemsFromArbitraryJson(string jsonStr) {
      JObject json = JObject.Parse(jsonStr);
    
      return json.Descendants().OfType<JProperty>()  // so we can filter by p.Name below
                 .Where(p => p.Name == "cartitems")
                 .SelectMany(p => p.Value)           // selecting the combined array (joined into a single array)
                 .Select(item => new CartItem {
                     Id  = (int)item["id"],
                     Qty = (int)item["qty"]
                 }).ToList();
    }
