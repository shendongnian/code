            public bool Visible
            {
                get { return this._visible; }
                set
                {
                    this._visible = value;
    
                    if (value)
                        SafeNativeMethods.ShowWindow(_form.Handle, 8);
                    else
                    {
                        //Here invoke _form:
                        this._form.Invoke(new MethodInvoker(() =>
                        {
                            _form.Hide();
                        }));
    
                    }
                }
            }
