        public void Switch()
        {
            var rootFrame = Window.Current.Content as Frame;
            
            if ((rootFrame.Content as ParentPage) != null)
            {
                rootFrame.Navigate(typeof(ChildPage));   
            }
        }
