    class Question {
        private event EventHandler AnsweredChanged;
        private bool isAnswered;
        ..
        ..
        public bool IsAnswered {
            get {
                return this.isAnswered;
            }
            set {
                if (this.isAnswered != value) { 
                    this.OnIsAnsweredChanged();
                }
            }
        }
        private void OnIsAnsweredChanged() {
             if (this.AnsweredChanged!= null) {
                  this.AnsweredChanged(this, EventArgs.Empty);
             }
        }
    }
