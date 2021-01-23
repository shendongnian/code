    private void castVote(String favoriete)
    {
        using (var connection = createConnection())
        {
            using (var cmd = new connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE docent SET aantalStemmen = aantalStemmen + 1 where docentid = @id";
                cmd.Parameters.AddWithValue("@id", cmbFavoriete.Text);
                // command must be actually executed, otherwise nothing happens
                cmd.ExecuteNonQuery();
            }
        }
    }
    private void btnStem_Click(object sender, EventArgs e)
    {
        string favoriet = cmbFavoriete.Text;
        bool r = isDisabled(favoriet);
        if (r) 
            castVote(favoriet);
            // maybe, it would make sense to also notify the user that the vote has been cast
        else
            MessageBox.Show("You have already voted.");
    }
