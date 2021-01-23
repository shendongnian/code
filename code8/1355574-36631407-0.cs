        static void Main(string[] args)
        {
 
            List<int> i = new List<int>(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20});
            List<int> r;
            r = ShuffleList(i);
            
           
        }
        private static List<E> ShuffleList<E>(List<E> unshuffledList)
        {
            List<E> sList = new List<E>();
            Random r = new Random();
            int randomIndex = 0;
            while (unshuffledList.Count > 0)
            {
                randomIndex = r.Next(0, unshuffledList.Count); 
                sList.Add(unshuffledList[randomIndex]);
                unshuffledList.RemoveAt(randomIndex); //remove so wont be added a second time
            }
            return sList; //return the new shuffled list
        }
    }
