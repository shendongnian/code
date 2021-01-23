    private void Recursive(IEnumerable ctrls)
        {
            foreach (var item in ctrls)
            {
                if (item is Panel)
                {
                    Recursive(((Panel)item).Controls);
                }
                else if(item is TextBox)
                {
                    if (((TextBox)item).Name.Contains("textBoxAddress"))
                    {
                       ((TextBox)item).Text = textchange;
                    }
                }
            }
        }
