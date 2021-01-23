        private void btnStop_Click(object sender, EventArgs e)
                {
                    if (Informacao.RadButtonValue == "Normal")
                    {
                        foreach (ListViewItem itemcheck in Informacao.mListView.CheckedItems)
                        {
                            if (itemcheck.Text == lblTimerScreenName.Text)
                            {
                                DialogResult result = MessageBox.Show(String.Format("Confirm changes to {0}", lblTimerScreenName.Text),
                                                                      "Please Confirm", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.OK)
                                {
                                    timer2.Stop();
                                    itemcheck.SubItems[1].Text = lblTimerScreenName.Text;
                                    SaveTime = textBox1.Text;
                                    itemcheck.SubItems[9].Text = SaveTime;
                                    itemcheck.SubItems[10].Text = Informacao.RadButtonValue;
                                }
                                break;
                            }
                        }
                    }
    ...
