      var encryptionItems = new Dictionary<string, string>
      {
        {"customerid", row.CustomerId.ToString()},
        {"firstname", model.FirstName},
        {"lastname", model.LastName}
      };
      var get = encryptionDal.EncryptDataWithSalt(encryptionItems, salt);
      var linkUri = get.Cast<object>().Aggregate(string.Empty, (current, item) => string.Concat(current, item.Key, "=", HttpUtility.UrlEncode(item.Value), "&"));
