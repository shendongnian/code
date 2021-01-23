        private HashSet<string> actionsEnabledSet = null;
        public HashSet<string> ActionsEnabledSet
        {
            get { return actionsEnabledSet; }
            set
            {
                actionsEnabledSet = value;
                NotifyOfPropertyChange(() => ActionsEnabledSet);
            }
        }
