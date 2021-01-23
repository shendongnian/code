        public static Boolean ValidateControle(Control MyObjet, int oblig=0)
        {
            ErrorProvider err=new ErrorProvider ();
     
            String mess = "";
            Boolean valid = true;
            if (MyObjet != null)
            {
              
                if (oblig == 1)
                {
          
                    mess = "Can not be empty !";
                }
                if (MyObjet.Text.Trim().Length == 0) valid = false;
                if (MyObjet is ComboBox)
                {
                    ComboBox cmb = (MyObjet as ComboBox);
                    if (cmb.SelectedIndex == -1)
                    {
                        mess = "Select at least one element !";
                        valid = false;
                    }
                }
                if (valid == false)
                {
                    err.SetError(MyObjet, mess);
                    MyObjet.BackColor = Color.FromArgb(253, 108, 119);
                }
                else
                {
                    err.SetError(MyObjet, "");
                    MyObjet.BackColor = Color.White;
                }
                err.SetIconAlignment(MyObjet, ErrorIconAlignment.BottomRight);
            }
            return valid;
        }
