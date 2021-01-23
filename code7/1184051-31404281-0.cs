         List<string> Capitals = (from u in db.Users
                                     select u.Name[0].ToString().ToUpper()).Distinct().ToList();
            telList.Items.Clear();
            for (int i = 0; i < alpha.Length; i++)
            {
                ListItem listItem = new ListItem(Convert.ToString(alpha[i]));
                listItem.Attributes.Add("value", Convert.ToString(i));
                for (int j = 0; j < Capitals.Count; j++)
                {
                    if (Convert.ToString(alpha[i]) == Capitals[j])
                    {
                        listItem.Attributes.Add("class", "class1");
                        break;
                    }
                    else
                    {
                        listItem.Attributes.Add("class", "class2");
                    }
                }
                telList.Items.Add(listItem);
            }
