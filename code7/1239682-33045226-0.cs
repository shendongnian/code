             string[] boxes = new string[30];
             string[] names = new string[30];
            for (int i = 1; i < boxes.Length; i++)
            {
                
                var label = this.Controls.Find("lb" + i, true)[0];
                var panelcontr = this.Controls.Find("panel" + i, true)[0] as Panel;
                var panels = panelcontr;
                
                var radiobutton = panels.Controls.OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);
                if(radiobutton==null)
                {
                    MessageBox.Show("Check all Buttons!");
                    break;
                }
                
                boxes[i] += radiobutton.Text;
                names[i] += label.Text;
                tobeWritten += names[i] + boxes[i] + ",";
                textBox1.Text = "Anamnese(" + tobeWritten + ")";
                
            }
        }
