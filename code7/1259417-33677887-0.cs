    private void button1_Click(object sender, EventArgs e)
      {
         int year = Convert.ToInt32(dBox_year.Text);
         filmList.Add(new Film(tbox_name.Text, tbox_director.Text, tbox_actor1.Text, tbox_actor2.Text, year, tbox_rating.Text));
         tbox_name.Text = string.Empty;
         tbox_director.Text = string.Empty;
         tbox_actor1.Text = string.Empty;
         tbox_actor2.Text = string.Empty;
         tbox_rating.Text = string.Empty;
         dBox_year.Text = string.Empty;
      }
