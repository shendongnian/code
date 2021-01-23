                Events.ColumnViewChanged += OnColumnViewChanged;
                Events.SortByTitle += OnSortByTitle;
                Events.SortByRunData += OnSortByRunData;
                Events.SortByElapsedTime += OnSortByElapsedTime;
                Events.GenerateHTMLReport += OnGenerateHTMLReport;
                Events.ShowAllFailedTests += OnShowAllFailedTests;
                Events.ShowAllPassedTests += OnShowAllPassedTests;
                
            }
    
            private void OnShowAllPassedTests(object sender, EventArgs e)
            {
                FilterCVS(tr => tr.DidTestPass);
            }
    
            private void OnShowAllFailedTests(object sender, EventArgs e)
            {
                FilterCVS(tr => tr.DidTestFail);
            }
