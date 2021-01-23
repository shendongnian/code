     private void ovalShape1_4_Click(object sender, EventArgs e)
    {
    Control ctrl = ((Control)sender);
            switch (index)
            {
                case 0:
                    ctrl.BackColor = Color.Yellow;
                    break;
                case 1:
                    ctrl.BackColor = Color.Green;
                    break;
                case 2:
                    ctrl.BackColor = Color.Red;
                    break;
                case 3:
                    ctrl.BackColor = Color.Purple;
                    break;
                default:
                    ctrl.BackColor = Color.Red;
                    index = 0;
                    break;
            }
    }
