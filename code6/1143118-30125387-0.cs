    public DataSet sortGenreCBox()
        {
            conn.Open();
            SqlCommand genreBox = new SqlCommand("Select Distinct" + sortByGenreCBox.SelectedItem + "from Sang", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(genreBox);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
                       
            conn.Close();
            return ds;
        }
