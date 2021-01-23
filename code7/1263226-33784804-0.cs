    public static DialogResult Show(string title, string message, ButtonStyle buttonStyle) {
        AFGMessageBox box = new AFGMessageBox();
        box.Text = title;
        box.LblMessage.Text = message;
        if (buttonStyle == ButtonStyle.Ok) {
            Button okButton = new Button {
                Width = 93,
                Height = 40,
                Location = new Point(x: 248, y: 202),
                Text = "OK",
                DialogResult = DialogResult.OK
            };
            box.Controls.Add(okButton);
        }
        return box.ShowDialog();
    }
