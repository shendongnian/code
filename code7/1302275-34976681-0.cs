     abstract class Cell
      {
            public virtual void passCell()
            {
                Console.WriteLine("Yo have been trying to pass a cell");
            }
      }
    class Bomb:Cell
     {
        public override void passCell()
        {
            Console.WriteLine("You have been trying to pass Bomb Cell !");
        }
     }
    class Gift:Cell
     {
        public override void passCell()
        {
            Console.WriteLine("You have been trying to pass Gift Cell !");
        }
      }
    class Wall:Cell
     {
     }
     class Program
        {
            static void Main(string[] args)
            {
                Cell[] cellArray=new Cell[3];
                cellArray[2]=new Bomb();
                cellArray[1]=new Gift();
                cellArray[0]=new Wall();
                for (byte i = 0; i < 3; i++)
                {
                    cellArray[i].passCell();
                }
                Console.ReadKey();
            }
        }
