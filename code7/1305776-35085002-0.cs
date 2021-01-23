    private class ControlCollectionEnumerator : IEnumerator {
        private ControlCollection controls; 
        private int current;
        private int originalCount;
        public ControlCollectionEnumerator(ControlCollection controls) {
            this.controls = controls;
            this.originalCount = controls.Count;
            current = -1;
        }
        public bool MoveNext() {
            // VSWhidbey 448276
            // We have to use Controls.Count here because someone could have deleted 
            // an item from the array. 
            //
            // this can happen if someone does:
            //     foreach (Control c in Controls) { c.Dispose(); }
            // 
            // We also dont want to iterate past the original size of the collection
            //
            // this can happen if someone does
            //     foreach (Control c in Controls) { c.Controls.Add(new Label()); }
            if (current < controls.Count - 1 && current < originalCount - 1) {
                current++;
                return true;
            }
            else {
                return false;
            }
        }
        public void Reset() {
            current = -1;
        }
        public object Current {
            get {
                if (current == -1) {
                    return null;
                }
                else {
                    return controls[current];
                }
            }
        }
    }
