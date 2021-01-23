        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mInputPane = InputPane.GetForCurrentView();
            mInputPane.Showing += InputPane_Showing;
            mInputPane.Hiding += InputPane_Hiding; 
        }
 ..
        private void InputPane_Showing(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            // Keyboard showing, get the size of the keyboard and adjust view.
            double keyboardHeight = args.OccludedRect.Height;
            aGridRow.Height = new GridLength(keyboardHeight);
            // Inform the system we have handled making the required UI visible.
            args.EnsuredFocusedElementInView = true;
        }
