    private void LetterA_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        dragLetterA.X += e.Delta.Translation.X;
        dragLetterA.Y += e.Delta.Translation.Y;
    }
    private void LetterB_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        dragLetterB.X += e.Delta.Translation.X;
        dragLetterB.Y += e.Delta.Translation.Y;
    }
    private void LetterC_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        dragLetterC.X += e.Delta.Translation.X;
        dragLetterC.Y += e.Delta.Translation.Y;
    }
    
