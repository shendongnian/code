    private void btnSub_Click(object sender, EventArgs e)
        {
            if (lst1.Items.Count != 0)
            {
                lst1.BeginUpdate();
                int j = 0;                
                foreach (int i in lst1.SelectedIndices)
                {
                    fileList.RemoveAt(i-j);
                    j++;
                }
                lst1.DataSource = null;
                lst1.DataSource = fileList; //resetting my bindlist so it displays the change i've made.
                lst1.EndUpdate();
            }
            else
            {
                MessageBox.Show("List is empty, nothing to remove...");
            }
        }
