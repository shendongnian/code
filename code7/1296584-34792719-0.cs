         void ShowOrCreate()
         {
            if(_form==null)
            {
                _form = new MyForm();
                _form.Closed += OnMyFormClosed();
                _form.Show();
            }
            else
            {
                _form.BringToFront();
            }
          }
          void OnMyFormClosed(...)
          {
             _form = null;
          }
