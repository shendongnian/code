    foreach (List1 item in list1)
            {
                if (item.Resim1 != null)
                    list2.Add(new List2() { Tag = item.Tag, Resim = item.Resim1 });
                if (item.Resim2 != null)
                    list2.Add(new List2() { Tag = item.Tag, Resim = item.Resim2 });
            }
