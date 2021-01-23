            int daystoend = t.DaysToEnd();
            int trialperiodruns = t.TrialPeriodRuns;
            /// Check if it is first run here 
            if (dte == 15 && tpr == 1000)
            {
                bool is_trial;
                /// then show the Registration dialog
                TrialMaker.RunTypes RT = t.ShowDialog();
                if (RT != TrialMaker.RunTypes.Expired)
                {
                    if (RT == TrialMaker.RunTypes.Full)
                        is_trial = false;
                    else
                        is_trial = true;
                    PharmacyManagementSystem.App app = new PharmacyManagementSystem.App();
                    app.InitializeComponent();
                    app.Run();
                }
            }
            /// Check if it is trial but not first run
            /// no Registration Dialog will show in this case
            else if (dte > 0 && tpr > 0)
            {
                PharmacyManagementSystem.App app = new PharmacyManagementSystem.App();
                app.InitializeComponent();
                app.Run();
            }
            /// Check if it is expired trial
            else if (dte == 0 || tpr == 0)
            {
                bool is_trial;
                /// then show the Registration Dialog here
                TrialMaker.RunTypes RT = t.ShowDialog();
                if (RT != TrialMaker.RunTypes.Expired)
                {
                    if (RT == TrialMaker.RunTypes.Full)
                        is_trial = false;
                    else
                        is_trial = true;
                    PharmacyManagementSystem.App app = new PharmacyManagementSystem.App();
                    app.InitializeComponent();
                    app.Run();
                }
            }
            /// the full version scenario remain and it comes here 
            /// no need to show Registration Dialog
            else
            {
                bool is_trial;
                TrialMaker.RunTypes RT = t.ShowDialog();
                if (RT != TrialMaker.RunTypes.Expired)
                {
                    if (RT == TrialMaker.RunTypes.Full)
                        is_trial = false;
                    else
                        is_trial = true;
                    PharmacyManagementSystem.App app = new PharmacyManagementSystem.App();
                    app.InitializeComponent();
                    app.Run();
                }
            }  
