    namespace CSharpWPF
    {
        class MyPanel : StackPanel
        {
            protected override Size MeasureOverride(Size constraint)
            {
                Size calculatedSize = base.MeasureOverride(constraint);
                foreach (ListBoxItem item in this.Children)
                {
                    //your logic with each item
                }
                return calculatedSize;
            }
        }
    }
