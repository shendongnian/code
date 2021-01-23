     Public async Task<IHttpActionResult> GetUserItem(string UserId, string ItemName)
     {
       UserItem item = await db.useritems.FirstOrDefault(c=>.UserId==UserId && c.ItemName==ItemName);
     }
    
