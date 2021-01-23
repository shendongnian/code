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
    int xstart = (x1 > x) ? x : x1;
    int ystart = (y1 > y) ? y : y1;
    int xend = (x1 > x) ? x1 : x;
    int yend = (y1 > y) ? y1 : y;
    for(int i=xstart;i<=xend;i++)
    {
        for(int j=ystart;j<=yend;j++)
        {
            sum += myArray[i,j];
        }
    }
    return sum;
    }
    }
