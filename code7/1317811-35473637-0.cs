    public interface IYesNoDialog {
        // DialogResult, I guess...
        // Whatever methods you need here to open the Dialog and control it.
    }
    public class YesNoDialog: Form, IYesNoDialog {
        //Implementation of the dialog here...
    }
    public class WhateverForm: Form {
        public IYesNoDialog YesNoDialog { get; set;}
        public WhateverForm() {
            this.YesNoDialog = new YesNoDialog();
        }
    }
