     public int[] Bar(){
       Contract.Ensures( Contract.ForAll(0, Contract.Result<int[]>().Length, index => Contract.Result<int[]>()[index] > 0));
 
     ....
     }
