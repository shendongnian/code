            private void mlkbuykg_TextChanged(object sender, EventArgs e)
            {
                int a,b;
                if (int.TryParse(mlkrate.Text, out a) && int.TryParse(mlkbuykg.Text, out b)){
                    int c = a * b;
                    mlktotal.Text = c.ToString();
                }
            }
