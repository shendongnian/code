     using (var ctx = new ClientContext(webUri))
     {
          var list = ctx.Web.Lists.GetByTitle(listTitle);
          var listItem = list.GetItemById(itemId);
          if(listItem.TryValidateAndUpdateChoiceFieldValue(fieldName,fieldValue))
            ctx.ExecuteQuery();
     }
