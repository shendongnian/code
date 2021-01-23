    public PartialViewResult RecentEmails()
            {
                int days = 2;
                
                List<HomeViewModel> viewModelList = new List<HomeViewModel>();
    
                for (int count = 0; count < days; count++)
                {
                    DateTime date = DateTime.Now.AddDays(count * (-1));
                    viewModelList.Add(new HomeViewModel
                    {
                        Date = date,
                        SnapshotItems = GetEmailSnapshot(9, date)
                        
                    });
                }
                
                return PartialView(viewModelList.AsEnumerable());
            }
