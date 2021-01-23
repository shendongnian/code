    public static class WindowsFormSingleton {
        
        // A static instance of your form
        private static WindowsForm _form;
    
        // A singleton property to interact with the form.
        public static WindowsForm Instance
        {
            get
            {
                if(_form == null) {
                    this._form = new WindowsForm();
                }
                return this._form;
            }
        }
    }
