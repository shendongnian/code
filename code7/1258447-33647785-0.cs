        private void SubscribeClick(PropertyGrid grid) {
            button.Click += new EventHandler(
                (sender, e) => button_Click(sender, e, grid)
            );
        }
