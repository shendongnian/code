        void LoadGamesAndRefreshView()
        {
            if (presenter.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)Delegate
                {
                    LoadGamesAndRefreshView();
                });
                return;
            }
            presenter.LoadGames();
            presenter.ApplyFilter();
        }
