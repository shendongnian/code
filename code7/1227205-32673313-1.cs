    private void buttonSearch_Click(object sender, EventArgs e)
    {
            string searchTerm = textBoxSearch.Text;
            List<string> searchWords = new List<string>(searchTerm.Split(new char[] { ' ' }));
            List<Person> searchResult = new List<Person>();
            foreach (string word in searchWords)
            {
                searchResult.AddRange(People.FindAll(p => p.Name.Contains(word, System.StringComparison.OrdinalIgnoreCase)));
                searchResult.AddRange(People.FindAll(p => p.Postort.Contains(word, System.StringComparison.OrdinalIgnoreCase)));
            }
            listBoxPeople.Items.Clear();
            foreach (Person person in searchResult)
            {
                listBoxPeople.Items.Add(person.ToListBoxString());
            }
            if (searchResult.Count == 0)
            {
                MessageBox.Show("Not found info! try again!");
            }
    } 
