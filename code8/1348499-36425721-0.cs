    class MyApp
    {
        double remX = 0;
        double remY = 0;
        double rateX = 0;
        double rateY = 0;
        private void mouseDeltaThread()
        {
            EventWaitHandle MyEventWaitHandle = new EventWaitHandle(false,EventResetMode.AutoReset);
            while (!Global.IsShuttingDown)
            {
                MyEventWaitHandle.WaitOne(1);
                if (rateX != 0 || rateY !=0)
                    setMouseDelta(rateX,rateY);
            }
        }
        private void setMouseDelta(double dX, double dY)
        {
            remX += (dX);
            remY += (dY);
            int moveX = (int)remX;
            int moveY = (int)remY;
            remX -= moveX;
            remY -= moveY;
            Shared.MoveCursorBy(moveX, moveY);
        }
    }
    internal static class Shared
    {
        public static void MoveCursorBy(int x, int y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            p.x += x;
            p.y += y;
            SetCursorPos(p.x, p.y);
        }
    }
