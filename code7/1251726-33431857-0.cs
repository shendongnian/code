    public void PreviousImageExecute()
    {
        if (SortedImageLibrary.CurrentPosition == 0)
        {
        }
        else
        {
            SortedImageLibrary.MoveCurrentToPrevious();
        }
        SelectedImage = SortedImageLibrary.CurrentItem as Image;
    }
    public void NextImageExecute()
    {
        if (SortedImageLibrary.CurrentPosition == SortedImageLibrary.Count - 1)
        {
        }
        else
        {
            SortedImageLibrary.MoveCurrentToNext();
        }
        SelectedImage = SortedImageLibrary.CurrentItem as Image;
    }
    
