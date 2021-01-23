    class MyCarouselPage : CarouselPage
    {
        private int totalPages;
        private int currentPage;
        public MyCarouselPage()
        {
            var pages = GetPages();
            totalPages = pages.Length;
            this.ChildAdded += MyCarouselPage_ChildAdded;
            for (int i = 0; i < totalPages; i++)
            {
                currentPage = i;
                this.Children.Add(pages[i]);
            }
        }
        void MyCarouselPage_ChildAdded(object sender, ElementEventArgs e)
        {
            var contentPage = e.Element as MyPageBase;
            if (contentPage != null)
            {
                contentPage.FinalStack.Children.Add(new CarouselPageIndicator(currentPage, totalPages, "indicator.png", "indicator_emtpy.png"));
            }
        }
        private MyPageBase[] GetPages()
        {
            var pages = new MyPageBase[] { new Page1(), new Page2() };
            return pages;
        }
    }
