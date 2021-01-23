     Action actUI = ()=>{
                         
                          Button button = new Button();
                          button.Text = get Data from newsearchresult ;
                          if (button.Text.Length >= 35)
                          {
                             button.Text.Remove(button.Text.Length - (button.Text.Length - 35));
                          }
                         button.Tag = get Data from newsearchresult ;;
                         button.TextImageRelation = TextImageRelation.ImageBeforeText;
                         button.FlatStyle = FlatStyle.Flat;
                         button.ForeColor = Color.LightSteelBlue;
                         button.BackColor = Color.SteelBlue;
                         button.Width = (flowLayoutPanel1.Width - 120);
                         button.TextAlign = ContentAlignment.MiddleLeft;
                         button.Height = 35;
                         button.Font = new Font(button.Font.FontFamily, 10);
                         flowLayoutPanel1.Controls.Add(button);
                      };
                if(flowLayoutPanel1.InvokeRequired)
                  flowLayoutPanel1.BeginInvoke(actUI);
                else
                  flowLayoutPanel1.Invoke(actUI);
