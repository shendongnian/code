        private bool isHolding = false;
        private bool canUserDragItem = false;
        // If a user moves their pointer outside the item's area or releases their pointer, stop all holding/dragging actions.
        private void Grid_StopAllowDrag(object sender, PointerRoutedEventArgs e)
        {
            canUserDragItem = false;
            isHolding = false;
        }
        // If a user starts dragging an item, check and see if they are holding the item first.
        private void itemGridView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            if (!canUserDragItem) e.Cancel = true;
        }
        private async void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Whenever a user presses the pointer inside the item, wait for half a second, then decide if the user is holding the item.
            isHolding = true;
            await Task.Delay(500); // Wait for some amount of time before allowing them to drag
            if (isHolding) // If the user is still holding, allow them to drag the item.
            { 
                canUserDragItem = true; // Allow them to drag now
                // TODO: Make it apparent that the user is able to drag the item now.
            }
        }
