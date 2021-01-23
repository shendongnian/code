        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = ((FrameworkElement)e.OriginalSource).Tag;
            if (tag != null && tag.ToString() == "Oops!")
            {
                return;
            }
            //else: do whatever needs to be done on item click
        }
