            private void btnNext_Click(object sender, EventArgs e)
            {
                // Next panel depends on item type selection
                string itemTypeSelection = comboItemType.Text;
                switch (elementTypeSelection)
                {
                    case "ITEM_A":
                        panel2B.Visible = true;
                        panel2B.BringToFront();
                        panel2B.Focus();
                        elementTypeSelection = "ITEM_B";
                        break;
                    case "ITEM_B":
                        panel2C.Visible = true;
                        panel2C.BringToFront();
                        panel2C.Focus();
                        elementTypeSelection = "ITEM_C";
                        break;
                    case "ITEM_C":
                        panel2D.Visible = true;
                        panel2D.BringToFront();
                        panel2D.Focus();
                        elementTypeSelection = "ITEM_D";
                        btnNext.Enabled = false;
                        break;
                    case "ITEM_D":
                        break;
                    default:
                        return;
                }
            }
