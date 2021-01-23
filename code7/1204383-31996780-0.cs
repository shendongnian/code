    if (player != null) {
        foreach(Models.Item item in itemDB.Items) {
            if (item.UserAssetOptionId == id) {
                if (!item.Owner.ToLower().Equals(username.ToLower())) {
                    return Content("false");
                } else {
                    item.Owner = "HomeguardDev";
                    item.InMarket = true;
                    player.Credits += item.Value / 10;
                    break;
                }
            }
        }
        try {
            itemDB.SaveChanges();
            userDB2.SaveChanges();
            return Content("true");
        } catch (Exception e) {
            Debug.WriteLine("FATAL ERROR: " + e.Message);
            return Content("false");
        }
    }
