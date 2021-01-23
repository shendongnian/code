            var list2Collection = new List<List2>();
            foreach (var item in lst1)
            {
                list2Collection.Add(new List2{ Tag = item.Tag, Resim = item.Resim1});
                list2Collection.Add(new List2 { Tag = item.Tag, Resim = item.Resim2 });
            }
