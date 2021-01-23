        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var rectangle = listView1.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    //Write your code here
                    return;
                }
            }
        }
