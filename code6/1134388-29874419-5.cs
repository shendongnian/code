            var madeForCommand = "SELECT ItemName as Name,ItemPicture as Picture,ItemHeroModif as Assistance,ItemTroopModif as Charisma, HerbCost as Herbs, GemCost as Gems FROM Item WHERE ";
            
            OleDbCommand command = new OleDbCommand();
            for (int ii = 0; ii < items.Count; ii++)
            {
                madeForCommand += "ItemId = ?  OR ";
                command.Parameters.AddWithValue("value" + ii, items[ii].ID);
            }
            madeForCommand = madeForCommand.Substring(0, madeForCommand.Length - 3);
