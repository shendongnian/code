        /// <devdoc>
        ///     The current text of the Window; if the window has not yet been created, stores it in the control.
        ///     If the window has been created, stores the text in the underlying win32 control.
        ///     This property should be used whenever you want to get at the win32 control's text. For all other cases,
        ///     use the Text property - but note that this is overridable, and any of your code that uses it will use
        ///     the overridden version in controls that subclass your own.
        /// </devdoc>
        internal virtual string WindowText {
            get {
 
                if (!IsHandleCreated) {
                    if (text == null) {
                        return "";
                    }
                    else {
                        return text;
                    }
                }
 
                using (new MultithreadSafeCallScope()) {
 
                    // it's okay to call GetWindowText cross-thread.
                    //
 
                    int textLen = SafeNativeMethods.GetWindowTextLength(new HandleRef(window, Handle));
 
                    // Check to see if the system supports DBCS character
                    // if so, double the length of the buffer.
                    if (SystemInformation.DbcsEnabled) {
                        textLen = (textLen * 2) + 1;
                    }
                    StringBuilder sb = new StringBuilder(textLen + 1);
                    UnsafeNativeMethods.GetWindowText(new HandleRef(window, Handle), sb, sb.Capacity);
                    return sb.ToString();
                }
            }
            set {
                if (value == null) value = "";
                if (!WindowText.Equals(value)) {
                    if (IsHandleCreated) {
                        UnsafeNativeMethods.SetWindowText(new HandleRef(window, Handle), value);
                    }
                    else {
                        if (value.Length == 0) {
                            text = null;
                        }
                        else {
                            text = value;
                        }
                    }
                }
            }
        }
