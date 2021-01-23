    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 1, 2, 3, 4, 5 };
            
            //destination array
            int[] newArray = new int[myArray.Length-1];
            
            //index of the element you want to delete
            var index = 3;
            //get and copy first 3 elements
            Array.Copy(myArray, newArray, index);
            //get and copy remaining elements without the 4th
            Array.Copy(myArray, index + 1, newArray, index, myArray.Length-(index+1));
            //Output newArray
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            for (int i = 0; i < newArray.Length; i++)
            {
                sb.Append(String.Format("#{0} {1}", i + 1, newArray[i]));                        
                if (!(i == newArray.Length - 1))
                {
                    sb.Append(", ");
                }
            }
            Console.Write(sb.ToString());
            Console.ReadLine();
        }
