     foreach (AsbtractClass Item in ItemCollection)
                {
                    if (Item is Book)
                        TxtResultBGenre.Text = System.Reflection.PropertyInfo BGenre = Item.GetType().GetProperty("BGenre").GetValue(Item).ToString();
                    else if (Item is Journal)
                        TxtResultJTopic.Text = System.Reflection.PropertyInfo JTopic = Item.GetType().GetProperty("JTopic").GetValue(Item).ToString();
                }
