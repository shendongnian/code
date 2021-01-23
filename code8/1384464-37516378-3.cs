    public class ArrayObjectPooling
    {
        int amount = 10;
        public GameObject[] objArray;
    
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
            GameObject firstObject = objArray[0];
    
            //Move everything Up by one
            shiftUp();
    
            return firstObject;
        }
    
        //Returns How much GameObject in the Array
        public int getAmount()
        {
            return amount;
        }
    
        //Moves the GameObject Up by 1 and moves the first one to the last one
        private void shiftUp()
        {
            //Get first GameObject
            GameObject firstObject = objArray[0];
    
            //Shift the GameObjects Up by 1
            Array.Copy(objArray, 1, objArray, 0, objArray.Length - 1);
    
            //(First one is left out)Now Put first GameObject to the Last one
            objArray[objArray.Length - 1] = firstObject;
        }
    }
