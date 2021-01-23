            protected override void OnApplyTemplate()
            {
                ...
                base.OnApplyTemplate();
                if (IsSelected)
                {
                    VisualStateManager.GoToState(this, "Selected", true);
                }
             }
