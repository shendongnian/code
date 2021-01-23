    public class ArrayObjectPooling
    {
        int amount = 10;
        GameObject[] objArray;
        int currentIndex = 0;
    
        public ArrayObjectPooling(GameObject objPrefab, string name, int count)
        {
            amount = count;
            objArray = new GameObject[amount];
    
            for (int i = 0; i < objArray.Length; i++)
            {
                objArray[i] = UnityEngine.Object.Instantiate(objPrefab, Vector3.zero, Quaternion.identity);
                objArray[i].SetActive(false);
                objArray[i].name = name + " #" + i;
            }
        }
    
        //Returns available GameObject
        public GameObject getAvailabeObject()
        {
            //Get the first GameObject
            GameObject firstObject = objArray[currentIndex];
    
            //Move the pointer down by 1
            shiftDown();
    
            return firstObject;
        }
    
        //Returns How much GameObject in the Array
        public int getAmount()
        {
            return amount;
        }
    
        //Moves the current currentIndex GameObject Down by 1
        private void shiftDown()
        {
            if (currentIndex < objArray.Length - 1)
            {
                currentIndex++;
            }
            else
            {
                //Reached the end. Reset to 0
                currentIndex = 0;
            }
        }
    }
