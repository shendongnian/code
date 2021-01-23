    internal static void ResetTextBoxes(Control root, string resetWith = "", params TextBox[] except)
    {
        foreach (TextBox txt in GetAllChildren(root).OfType<TextBox>())
        {
            if(!except.Any(t => t.Name == txt.Name))
                {
                    txt.Text = resetWith == "" ? string.Empty : resetWith;
                }
            }
        }
    }
