        private void tbLast_TextChanged(object sender, EventArgs e)
        {
            if (tbLast.Focused && tbLast.Text != "")
            {
                if (lbContact.FindString(tbLast.Text) > -1)
                {
                    lbContact.SetSelected(lbContact.FindString(tbLast.Text), true);
                }
            }
        }
        private void lbContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show details of contact selected in listbox
            string findNames = lbContact.GetItemText(lbContact.SelectedItem);
            StreamReader obRead = new StreamReader(fileName);
            using (obRead)
            {
                while (!obRead.EndOfStream)
                {
                    string rdLine = obRead.ReadLine();
                    if (rdLine.StartsWith(findNames))
                    {
                        string[] tmpArr = rdLine.Split(',');
                        if (!tbLast.Focused)
                        {
                            tbLast.Text = tmpArr[0];
                            tbFirst.Text = tmpArr[1].Trim();
                            tbAddr.Text = tmpArr[2].Trim();
                            tbSub.Text = tmpArr[3].Trim();
                            tbPost.Text = tmpArr[4].Trim();
                            tbEmail.Text = tmpArr[5].Trim();
                            tbPhone.Text = tmpArr[6].Trim();
                            tbMob.Text = tmpArr[7].Trim();
                        }
                    }
                }
                lbContact.SelectedIndex = lbContact.FindString(findNames);
            }
        }
