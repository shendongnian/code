    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace MyProgram
    {
        class CustomMessageBox
        {
            Label txtMsg = new Label();
            Button btnOK = new Button();
            Button btnCancel = new Button();
            Form newForm = new Form();
    
            private DialogResult spawnForm(string title, string text, MessageBoxButtons type)
            {            
                if(type == MessageBoxButtons.OKCancel)
                {
                    newForm.Text = title;
                    newForm.Controls.Add(txtMsg);
                    txtMsg.AutoSize = true;
                    txtMsg.Text = text;
                    newForm.Width = txtMsg.Width + 125;
                    newForm.Height = txtMsg.Height + 125;
                    newForm.MaximumSize = new Size(newForm.Width, newForm.Height);
                    newForm.MinimumSize = new Size(newForm.Width, newForm.Height);
                    txtMsg.Location = new Point(newForm.Width / 2 - txtMsg.Width / 2, newForm.Height / 2 - 40);
                    newForm.Controls.Add(btnOK);
                    newForm.Controls.Add(btnCancel);
                    btnOK.Text = "OK";
                    btnCancel.Text = "Cancel";
    
                    btnOK.Location = new Point(newForm.Width / 2 - btnOK.Width / 2 - 60, txtMsg.Location.Y + txtMsg.Height + 20);
                    btnCancel.Location = new Point(newForm.Width / 2 - btnOK.Width / 2 + 40, btnOK.Location.Y);
                    btnOK.DialogResult = DialogResult.OK;
                    btnCancel.DialogResult = DialogResult.Cancel;
                    newForm.StartPosition = FormStartPosition.CenterParent;
                    return newForm.ShowDialog();
                } else
                {                
                    newForm.Text = title;
                    newForm.Controls.Add(txtMsg);
                    txtMsg.AutoSize = true;
                    txtMsg.Text = text;
                    newForm.Width = txtMsg.Width + 125;
                    newForm.Height = txtMsg.Height + 125;
                    newForm.MaximumSize = new Size(newForm.Width, newForm.Height);
                    newForm.MinimumSize = new Size(newForm.Width, newForm.Height);
                    txtMsg.Location = new Point(newForm.Width / 2 - txtMsg.Width / 2 - 10, newForm.Height / 2 - 40);
                    newForm.Controls.Add(btnOK);
                    newForm.Controls.Remove(btnCancel);
                    btnOK.Text = "OK";
                    btnOK.Location = new Point(newForm.Width / 2 - btnOK.Width / 2 -10, txtMsg.Location.Y + txtMsg.Height + 20);
                    btnOK.DialogResult = DialogResult.OK;
                    newForm.StartPosition = FormStartPosition.CenterParent;
                    return newForm.ShowDialog();
                }              
            }   
    
            public DialogResult Text(string title, string text, MessageBoxButtons type)
            {
                return spawnForm(title, text, type);
            }
        }
    }
