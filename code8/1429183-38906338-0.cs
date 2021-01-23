    class ImageSearcher
    {
        private Queue<DirectoryInfo> found = new Queue<...>();
        public void ImageSearchByDir(DirectoryInfo dir)
        {
             found.Enqueue(dir);
             RealSearch();
        }
        private void RealSearch()
        {
             while(found.Count > 0)
             {
                 var current = found.Dequeue()
                 
                 // do your filtering on the current folder
                 
                 // then add the children directories
                 foreach(dir in current.GetDirectories())
                 {
                     found.Enqueue(dir);
                 }
             }  
        }
    }
