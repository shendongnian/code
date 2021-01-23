    connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=dbNotes;Integrated Security=True;MultipleActiveResultSets=true");
            categoriesUI1.tvwCategories.SelectedNode = categoriesUI1.tvwCategories.TopNode;
            int count = categoriesUI1.Categories.Count;
            if (count > 0)
            {
                for (int i = count; i > 0; i = count)
                {
                    categoriesUI1.Categories.RemoveAt(0);
                    count = categoriesUI1.Categories.Count;
                }
            }
            connection.Open();
            SqlCommand commandCategory = new SqlCommand("SELECT ID, Titel from tblCategory", connection);
            SqlDataReader readerCategory = commandCategory.ExecuteReader();
            if (readerCategory.HasRows)
            {
                while (readerCategory.Read())
                {
                    int id = readerCategory.GetInt32(0);
                    string titel = readerCategory.GetString(1);
                    Category category = new Category(id, titel);
                    SqlCommand commandNote = new SqlCommand("SELECT ID, Cat_ID, Titel, Text, Created FROM tblNote WHERE Titel LIKE '%" + searchBarUI1.getTextValue() + "%'", connection);
                    SqlDataReader readerNote = commandNote.ExecuteReader();
                    if (readerNote.HasRows)
                    {
                        while (readerNote.Read())
                        {
                            int catID = readerNote.GetInt32(1);
                            if (catID == id)
                            {
                                int noteID = readerNote.GetInt32(0);
                                string noteTitel = readerNote.GetString(2);
                                string noteText = readerNote.GetString(3);
                                DateTime noteCreated = readerNote.GetDateTime(4);
                                Note note = new Note(noteID, noteTitel, noteText, noteCreated);
                                category.Notes.Add(note);
                            }
                        }
                    }
                    if(category.Notes.Count > 0)
                        categoriesUI1.Categories.Add(category);
                }
            }
