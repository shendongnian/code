              public string txt_name;
              public void setValues()
              {
                 lbl_text.Text = txt_name;
              }
              public string set_lbl_text
              {
                 get { return lbl_Task_text.Text; }
                 set {
                         this.txt_name = value;                    
                     }
              }
