            List<test> li = new List<test>();
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                li.Add(new test()
                {
                    Name1 = "Anobik1" + i.ToString(),
                    Name2 = "Anobik1"                    +i.ToString(),
                    Name3 = "Anobik1"                    +i.ToString()
                });
            }
            MyList.ItemsSource = li;
        }
