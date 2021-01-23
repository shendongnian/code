     private void save_file()
        {
            string path = Directory.GetCurrentDirectory() + @"\list.txt";
            string json = JsonConvert.SerializeObject(postlist);
            File.WriteAllText(path, json);
            Application.Exit();
        }
