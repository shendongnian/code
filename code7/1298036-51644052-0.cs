    class Friend
    {
        public string Name { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public int Birthday { get; set; }
    }
    class MainWindow
    {
        List<Friend> friends = new List<Friend>();
        //other functions here populated the list
        private void OnButtonClick(object sender, EventArgs e)
        {
            Friend[] sortedArray = friends.OrderBy(f => f.Name).ToArray();
            int index = Array.BinarySearch(sortedArray, new Friend() { Name = tb_binarySearch.Text });
            
            if (index < 0)
            {
                Console.WriteLine("Friend does not exist in list");
            } 
            else
            {
                Console.WriteLine("Your friend exists at index {0}", index);
            }
            
        }
    }
