    public int? GetUserId()
    {
       if (context.User.Identity.IsAuthenticated)
        {
           var id=context.User.FindFirst(ClaimTypes.NameIdentifier);
           if (!(id is null) && int.TryParse(id.Value, out var userId))
                return userId;
         }
          return new Nullable<int>();
     }
