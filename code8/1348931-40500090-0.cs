            MessagingCenter.Subscribe<NavigationPage>(this, "Navigate", (pageItem) =>
            {
                pageItem.Parent = null; // solution
                Detail = pageItem;
                IsPresented = false;
            });
