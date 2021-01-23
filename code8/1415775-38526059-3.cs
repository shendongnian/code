internal void EvaluateHasVisibleChild()
{
  foreach(ViewModelType node in Items)
    // Conditions for ultimate visibility
    if (node.IsVisible && node.HasVisibleChild)
    {
      HasVisibleChild = true;
      return;
    }
  HasVisibleChild = false;
}
