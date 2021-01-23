    private void dgTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (cmb01 != null && cmb02 != null && cmb03 !=null)
                {
                    cmb1 = cmb01.SelectionBoxItem.ToString();
                    cmb2 = cmb02.SelectionBoxItem.ToString();
                    cmb3 = cmb03.SelectionBoxItem.ToString();
                    MessageBox.Show(cmb1 + cmb2+cmb3);
                }
            }
