            if (getByChosenField.OfType<Reading>().Any()) // Faster than Count() > 0
            {
                foreach (Reading item in getByChosenField.OfType<Reading>())
                {
                    LibraryList.Items.Add(
                        new MyItems
                        {
                            ItemName = item.ItemName,
                            CopyNumber = int.Parse(item.CopyNumber.ToString()),
                            Guid = int.Parse(item.Guid.ToString()),
                            TimePrinted = item.Time,
                            BestSeller = item.BestSeller,
                            Category = item.BookCategory.ToString(),
                            SubCategory = item.ReadingBookSubCategory.ToString()
                        });
                }
            }
