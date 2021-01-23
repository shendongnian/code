        /// <summary>
        /// initail your  UI
        /// </summary>
        void ini()
        {
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
        }
        /// <summary>
        /// this is for add all searchressult Cates to to Treeview
        /// </summary>
        /// <param name="sKey"></param>
        void SearchCate(string sKey)
        {
               connection.Open();
            SqlCommand commandCategory = new SqlCommand("SELECT Titel FROM tblCategory WHERE ID in ( 
    SELECT ID  FROM tblNote WHERE Titel LIKE '%" + sKey +
                                    "%') " + Cat_id, connection);
            SqlDataReader readerCategory = commandCategory.ExecuteReader();
            if (readerCategory.HasRows)
            {
                while (readerCategory.Read())
                {
                    Cat_title = readerCategory.GetString(0);
                    category = new Category(Cat_id, Cat_title); // new category
                    categoriesUI1.Categories.Add(category);
                    // then add your note's search result here to eavcgorhe
                    AddNoteToACateBySearchKey(sKey,category);
                }
            }
        }
        /// <summary>
        /// add all searchresult note to cate 
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="Parent"></param>
  
        void AddNoteToACateBySearchKey(string sKey, Category Parent )
        {
            connection.Open();
            SqlCommand commandNote = new SqlCommand("SELECT ID, Cat_ID, Titel, Text, Created FROM tblNote WHERE Titel LIKE '%" + sKey + "%' and Cat_ID='" + Parent.Cat_id + "' ", connection);
            SqlDataReader readerNote = commandNote.ExecuteReader();
            if (readerNote.HasRows)
            {
                Category category = new Category();
                while (readerNote.Read())
                {
                    int id = readerNote.GetInt32(0);
                    int Cat_id = readerNote.GetInt32(1);
                    string title = readerNote.GetString(2);
                    string text = readerNote.GetString(3);
                    DateTime created = readerNote.GetDateTime(4);
                    string Cat_title = "";
                    Note note;
                    note = new Note(id, title, text, created); // new note
                    category.Notes.Add(note);
                    readerCategory.Close();
                }
            }
            readerNote.Close();
            connection.Close();
        }
