     private void AddHubSection(IEnumerable<DaySummary> list)
            {
                if (list != null)
                {
                    list = list.OrderByDescending(x => x.Date);
                    foreach (var item in list)
                    {
                        if (item.Date.Date.Equals(DateTime.Now.Date))
                        {
                            continue;
                        }
    
                        HubSection hubSection = new HubSection();
                        TextBlock headerTextBlock = new TextBlock();
                        headerTextBlock.Text = item.Date.ToString("dddd dd.MMM");
                        headerTextBlock.FontSize = 15;
                        hubSection.Header = headerTextBlock;
                        hubSection.Margin = new Thickness(0);
    
                        object dataTemplate;
                        this.Resources.TryGetValue("DataTemplate", out dataTemplate);
                        hubSection.ContentTemplate = dataTemplate as DataTemplate;
                        hubSection.DataContext = item;
                        hubSection.DoubleTapped += HubSection_DoubleTapped;
                        MainHub.Sections.Add(hubSection);
                    }
                }
            }
