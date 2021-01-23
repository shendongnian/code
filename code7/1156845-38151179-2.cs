    class Page1:MyPageBase
    {
        public Page1()
        {
            var layout = new StackLayout
            {
                Children = {
                    new Label{Text="Page 1"}
                }
            };
            this.FinalStack = layout;
            this.Content = FinalStack;
        }
    }
