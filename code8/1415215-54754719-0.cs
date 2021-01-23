    List<int> iList = new List<int>(); 
        private void shift(int n)
        {
            for (int i = 0; i < n; i++)
            {
                iList.Add(iList[0]);
                iList.RemoveAt(0);
            }
            
        }
