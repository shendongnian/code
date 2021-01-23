        private void buttonSetup_Click(object sender, EventArgs e) {
            using (var adminForm = new AdminForm()) {
                foreach (var button in Controls.OfType<Button>().Where(bt => !bt.Text.Contains("Setup"))) {
                    adminForm.Controls.Add(new CheckBox {
                        Text = button.Text,
                        Location = button.Location
                    });
                }
                adminForm.ShowDialog();
            }
        }
