     for (int i = 0; i < isolatedGroup.Items.Count; i++)
                    {
                        if (!assetsGroup.Items.Contains(isolatedGroup.Items[i]))
                        {
                            isolatedGroup.Items.RemoveAt(i);
                            i--;
                        }
                    }
