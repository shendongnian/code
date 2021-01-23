    private void YourOtherMethod()
    {
        // do stuff
        var sum = SelectedDisplayItems.Sum(item => item.ItemSellingPrice ?? 0); // Since ItemSellingPrice can be null, use 0 instead
        // do more stuff
    }
