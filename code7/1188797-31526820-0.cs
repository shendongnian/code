    public class boxes{
    public int[6,6] myArray;
    public void boxes(){ // This is just a constructor. 
    myArray = {{2,1,4,3,1,2,5}
                    ,{4,2,3,3,1,2,4}
                    ,{3,4,9,1,2,7,5}
                    ,{1,6,2,1,3,4,2}
                    ,{2,1,4,6,2,1,0}
                    ,{6,2,8,1,6,5,7}
                    ,{7,6,10,3,9,7,2}};
    }
    public int BoxSum(int x, int y, int x1, int y1) {
    int sum = 0;
    for(int i=x;i<=x1;i++)
    {
        for(int j=y;j<=y1;j++)
        {
            sum += myArray[i,j];
        }
    }
    return sum;
    }
    }
