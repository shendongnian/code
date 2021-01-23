        if (await SqLiteFacade.InitializeDatabase())
        {
            var group = new SqliteDataGroup()
            {
                Description = "desc",
                Title = "my title",
                Image = "img",
                Subtitle = "subtitle",
                Items = new List<SqliteDataItem>()
                    {
                        new SqliteDataItem()
                        {
                            ItemContent = "Item 1"
                        },
                        new SqliteDataItem()
                        {
                            ItemContent = "Item 2"
                        },
                        new SqliteDataItem()
                        {
                            ItemContent = "Item 3"
                        }
                    }
            };
            
            SqLiteFacade.DbConnection.InsertWithChildren(group);
            var results = SqLiteFacade.DbConnection.GetAllWithChildren<SqliteDataGroup>();
        }
