    class AutoCompleteLookUpEdit : LookUpEdit {
        List<string> suggestions = new List<string>();
        public AutoCompleteLookUpEdit() {
            Properties.DataSource = suggestions;
            Properties.ImmediatePopup = true;
        }
        protected override void ProcessFindItem(KeyPressHelper helper, char pressedKey) {
            suggestions.Clear();
            // add search suggestions here depending on helper.Text value
            suggestions.Add("google");
            suggestions.Add("devexpress");
            // ...
            base.ProcessFindItem(helper, pressedKey);
        }
    }
