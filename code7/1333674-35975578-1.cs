        void FindTextBoxex(object uiElement, IList<TextBox> foundOnes)
        {
            if (uiElement is TextBox)
            {
                foundOnes.Add((TextBox)uiElement);
            }
            else if (uiElement is Panel)
            {
                var uiElementAsCollection = (Panel)uiElement;
                foreach (var element in uiElementAsCollection.Children)
                {
                    FindTextBoxex(element, foundOnes);
                }
            }
            else if (uiElement is UserControl)
            {
                var uiElementAsUserControl = (UserControl)uiElement;
                FindTextBoxex(uiElementAsUserControl.Content, foundOnes);
            }
            else if (uiElement is ContentControl)
            {
                var uiElementAsContentControl = (ContentControl)uiElement;
                FindTextBoxex(uiElementAsContentControl.Content, foundOnes);
            }
        }
