            try
            {
                var documentsBuilder = this.oneDriveClient.Drive.Root.ItemWithPath("Documents");
                var children = await documentsBuilder.Children.Request().GetAsync();
                // try to find existing folder
                var folder = children.FirstOrDefault(c => c.Name.Equals("Some folder"));
                // create it if it doesn't exist
                if (folder == null)
                {
                    var newFolder = new Item { Name = "Some folder", Folder = new Folder() };
                    await documentsBuilder.Children.Request().AddAsync(newFolder);
                }
            }
            catch (OneDriveException exception)
            {
                throw;
            }
