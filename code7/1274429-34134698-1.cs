    public static bool MouseClicked { get; set; }
            static void Main(string[] args)
            {
                MouseClicked = false;
                Thread myClickedThread = new Thread(() =>
                {
                    do
                    {
                        //Your Code
                        //If this is a WPF application you will require a Dispacther.Invoke -> This is to access the main thread were the View resides.
                    } while (!MouseClicked);
                });
                myClickedThread.Start(); //Remember to start the thread
            }
    
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                MouseClicked = true;
                clickedX = e.X;
                clickedY = e.Y;
                clickedX = MatchField(clickedX);
                clickedY = MatchField(clickedY);
                if (player1[clickedX, clickedY] == 0 && player2[clickedX, clickedY] == 0 && clickedX != 5 && clickedY != 5) mouseClicked = true;
            }
