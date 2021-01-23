        // Process one label only.
        public void ProcessLabel(int i)
        {
            // ... body of for loop ...
        }
        // Store current index between clicks.
        private int CurrentIndex
        {
            get { return (int)Session["MyCurrentIndex"]; }
            set { Session["MyCurrentIndex"] = value; }
        }
        // Processes one label, per click.
        private void Button1_Click(object sender, EventArgs e)
        {
            int i = CurrentIndex;
            if (i >= 161)
                return;     // End of for loop
            ProcessLabel(i);
            // On next click, CurrentIndex+1 will be processed.
            CurrentIndex = i + 1;
        }
        // Call this function during page initialisation.
        private void OnInit()
        {
            // Set initial value
            CurrentIndex = 0;
        }
