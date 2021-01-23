     private void Move(Item source, int sourceIndex, int targetIndex)
            {
                IList<Item> prevItems = _items;
                
                try
                {
                    _items.RemoveAt(sourceIndex);
                    _items.Insert(targetIndex, source);
    
                }
                catch(ArgumentOutOfRangeException)
                {
                    //User doesn't need to be notified about this. It just means that they dragged out of the box they were ordering. 
                    //The application does not need to be stopped when this happens.
                    _items = prevItems;
                    Debug.WriteLine("User tried to drag between boxes.. Order of boxes were not changed. ");
    
                }
            }
