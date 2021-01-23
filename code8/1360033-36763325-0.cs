                private void bttnAdd_Click(object sender, EventArgs e)
                {
                    int bet = int.Parse(lblBet.Text);
                    lblBet.Text = bet<5 ? ++bet : 1;
                }
