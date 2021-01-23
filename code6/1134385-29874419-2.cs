            string madeForCommand = "SELECT ItemName as Name,ItemPicture as Picture,ItemHeroModif as Assistance,ItemTroopModif as Charisma, HerbCost as Herbs, GemCost as Gems FROM Item WHERE ";
            int count = 0;
            foreach (shopItem item in items)
            {
                madeForCommand += "ItemId = @value" + count + " OR ";
                count++;
            }
            madeForCommand = madeForCommand.Substring(0, madeForCommand.Length - 3);
            OleDbCommand command = new OleDbCommand();
            for(int ii=0;ii<items.Count;ii++)
            {
                command.Parameters.AddWithValue("@value" + ii, items[ii].ID);
            }
