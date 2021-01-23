    try {
      if (adsSearchResult.Properties["mail"]!= null && adsSearchResult.Properties["mail"].Any()) {
          var mail = adsSearchResult.Properties["mail"][0];
          if (mail == null) {
              Label3.Text = "blablabla";
              return;
          } else {
              Session["email"] = adsSearchResult.Properties["mail"][0].ToString()
                  .ToLower();
          }
      }
    } catch (Exception ex) {
      Response.Write(ex);
    }
