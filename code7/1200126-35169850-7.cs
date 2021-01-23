       // Somewhere in the initializer or constructor for the page
       yourViewModel.StatusChanged += yourViewModel_StatusChanged;
       // The handler for StatusChanged
       private void yourViewModel_StatusChanged(object sender, StatusChangedHandlerArgs args)
        {
            var block = sender as Block;
            if (block != null)
            {
                BlockList.ScrollIntoView(block);
            }
        }
