            var imm = (InputMethodManager)GetSystemService(InputMethodService);
            if (isEditable)
            {
                et.Focusable = true;
                et.Enabled = true;
                et.Clickable = true;
                et.FocusableInTouchMode = true;
                et.SetSelection(et.Text.Length);
                et.RequestFocus();
                imm.ShowSoftInput(et, ShowFlags.Implicit);
            }
            else
            {
                et.Focusable = false;
                et.FocusableInTouchMode = false;
                et.Clickable = true;
                imm.HideSoftInputFromWindow(et.WindowToken, HideSoftInputFlags.None);
            }
        }
