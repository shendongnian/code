    string oldText = null;
    bool isThreadBusy = false;
    private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            oldText = searchControl1.Text;
            if (isThreadBusy) return;
            isThreadBusy = true;
            if (!string.IsNullOrEmpty(searchControl1.Text))
            {
    
                group.Items.Clear();
    
                ParameterizedThreadStart pts = new ParameterizedThreadStart(searchMyData);
                Thread t = new Thread(pts);
                t.Start(searchControl1.Text);
            }
            else
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
                Thread t = new Thread(pts);
                t.Start();
            }
        }
        //You also must implement this technic on LoadBooks
        public void searchMyData(object state)
        {
             try{} catch{}
            finally
            {
                 // Check if searchControl1.Text changed during the time this method execute. If changed, call this function again, pass new string.
                 isThreadBusy = false;
            }
        }
        public void searchMyData(object state)
        {
            string text = state.ToString();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(MyConnectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    //cmd.CommandText = "SELECT * from booktable where booktitle like'" + text + "%' OR bookauthor like'" + text + "%' ";
    
    
                    cmd.CommandText = "SELECT * from booktable where Match(booktitle) Against(@names IN BOOLEAN MODE) OR Match(bookauthor) Against(@names IN BOOLEAN MODE)";
                    cmd.Parameters.AddWithValue("@names", text.ToString()+"*".ToString());
                    //cmd.Parameters.AddWithValue("@author", text.ToString() + "*".ToString());
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    adap.Fill(ds);
                    DataView dv = new DataView();
                    Invoke(new Action(() =>
                    {
                        for (int i = 0; i < ds.Rows.Count; i++)
                        {
                            byte[] byteBLOBData = (byte[])ds.Rows[i]["bookphoto"];
                            var stream = new MemoryStream(byteBLOBData);
    
                            Image bookimages = Image.FromStream(stream);
                            string author = ds.Rows[i]["bookauthor"].ToString();
                            string title = ds.Rows[i]["booktitle"].ToString();
    
                            //Add Books in the Gallery Control for every text changed 
                            group.Items.Add(new GalleryItem(bookimages, title, author));
                            group.Items[i].HoverImage = group.Items[i].Image;
    
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                 // Check if searchControl1.Text changed during the time this method execute. If changed, call this function again, pass new string.
                 isThreadBusy = false;
            }
        }
