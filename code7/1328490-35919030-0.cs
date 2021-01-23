    DisplayModeProvider.Instance.Modes.Insert(0, new NewSiteDisplayMode()
            {
                ContextCondition = context => IshkaDisplayMode.IsNewSite(context.Request)
               
            });
