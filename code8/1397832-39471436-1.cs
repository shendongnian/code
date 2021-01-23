            MongoCollection<Task> collection = GetTaskCollection();
            try
            {
                collection.Insert(task);
            }
            catch(MongoCommandException ex)
            {
              string message = ex.Message;
            }
        }
        private void insert_Click(object sender, EventArgs e)
        {
            string name = txtBxName.Text;
            string song = txtBxSong.Text;
            Task t = new Task
            {
                Name = name,
           
                Song = song
            };
            Dal d = new Dal();
            List<Task> list = new List<Task>(200);
            list.Add(t);
            data.DataSource = list;
        }
