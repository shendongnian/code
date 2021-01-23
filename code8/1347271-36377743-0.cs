        protected override void OnClick(EventArgs e)
        {
            // Get the clicked item
            int ItemYPosition = 0;
            foreach (string Item in Items)
            {
                Rectangle ItemRectangle = new Rectangle(0, ItemYPosition,
                                                        this.Width, _ItemHeight);
                if (ItemRectangle.Contains(e.Location)) // found one hit!
                   
                ItemYPosition += _ItemHeight;
            }
        }
