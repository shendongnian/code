    public class ArrayObjectPooling
    {
        const int amount = 10;
        GameObject[] springs;
    
        public ArrayObjectPooling()
        {
            springs = new GameObject[amount];
        }
    
        //Returns available GameObject
        public GameObject getAvailabeSpring()
        {
            //Get the first GameObject
            GameObject firstObject = springs[0];
    
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
            GameObject firstObject = springs[0];
    
            //Shift the GameObjects Up by 1
            Array.Copy(springs, 1, springs, 0, springs.Length - 1);
    
            //(First one is left out)Now Put first GameObject to the Last one
            springs[springs.Length - 1] = firstObject;
        }
    }
