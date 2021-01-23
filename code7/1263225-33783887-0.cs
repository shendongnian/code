    public static DialogResult Show(string title, string message, ButtonStyle buttonStyle) {
        AFGMessageBox box = new AFGMessageBox();
        box.Text = title;
        box.LblMessage.Text = message;
        if(buttonStyle == ButtonStyle.Ok) {
            Button okButton = new Button {
                Width = 93,
                Height = 40,
                Location = new Point(x: 248, y: 202),
                Text = "OK"
            };
            box.Controls.Add(okButton); // add the button to your dialog!
            okButton.Click += (s, e) => { // add click event handler as a closure
                box.DialogResult = DialogResult.OK; // set the predefined result variable
                box.Close(); // close the dialog
            };
        }
        return box.ShowDialog(); // display the dialog! (it returns box.DialogResult by default)
    }
