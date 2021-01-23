    foreach (AsbtractClass Item in ItemCollection)
            {
                System.Reflection.PropertyInfo BGenre = Item.GetType().GetProperty("BGenre");
                System.Reflection.PropertyInfo JTopic = Item.GetType().GetProperty("JTopic");
    
                if (BGenre != null) TxtResultBGenre.Text = BGenre.GetValue(Item).ToString();
                if (JTopic != null) TxtResultJTopic.Text = BGenre.GetValue(Item).ToString();
            }
