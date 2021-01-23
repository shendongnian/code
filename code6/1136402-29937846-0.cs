    var madeForCommand = "SELECT ItemName as Name,ItemPicture as Picture,ItemHeroModif as Assistance,ItemTroopModif as Charisma, HerbCost as Herbs, GemCost as Gems " +
        "FROM Item WHERE (ItemID in (";
         OleDbCommand command = new OleDbCommand();
         for (int ii = 0; ii < items.Count; ii++)// items is a list of items with IDs I want to get from the query.
         {
              if (i<=1) {
                  madeForCommand += items[ii].ID
              }else {
                  madeForCommand += "," + items[ii].ID;
              }
         }
        madeForCommand += "))"
