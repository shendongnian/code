    IEnumerable<T> GetValues<T>() {
      var query = db.Table
          .Where(a => a.CustomFieldId == FieldID && a.ListingId == listingID);
    
      if (typeof(T)==typeof(bool)) {
        return query.Select(x => x.BoolColumn);
      }
      else if (typeof(T) == typeof(int)) {
        return query.Select(x => x.IntColumn);
      }
      // other types here
    }
