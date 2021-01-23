        private static void MoveToNextMatch(TextBoxBase box, bool forward) {
            var needle = box.SelectedText;
            var haystack = box.Text;
            int index = box.SelectionStart;
            if (forward) {
                index = haystack.IndexOf(needle, index + 1);
                if (index < 0) index = haystack.IndexOf(needle, 0);
            }
            else {
                if (index == 0) index = -1;
                else index = haystack.LastIndexOf(needle, index - 1);
                if (index < 0) index = haystack.LastIndexOf(needle, haystack.Length - 1);
            }
            if (index >= 0) {
                box.SelectionStart = index;
                box.SelectionLength = needle.Length;
            }
            box.Focus();
        }
