    internal class ButtonLabelPair
    {
        internal Button AssociatedButton { get; private set; }
        internal Label AssociatedLabel { get; private set; }
        internal ButtonLabelPair(Button associatedButton, Label associatedLabel)
        {
            AssociatedButton = associatedButton;
            AssociatedLabel = associatedLabel;
        }
    }
