    using System.Windows.Forms;
    using AionInterface;
    using System.Threading;
    
        namespace mover
        {
            public class MoveToCoord : IAionInterface
            {
                Thread tr;
                public MoveToCoord()
                {
                    tr = new Thread(LetsWork);
                }
        
                public void Sleep(int ms)
                {
                    Thread.Sleep(ms);
                }
        
                public void SetPosition(float x, float y, float z)
                {
                    Game.Player.SetPosition(x, y, z);
                }
        
                public void OnClose()
                {
                    return;
                }
        
                public void OnLoad()
                {
                    //Game.Register("FindTarget", "f", KeysModifier.Control);
                }
        
                public void OnRun()
                {
                    tr.Start();
                }
        
                public void LetsWork()
                {
                    for (int i=0;i<6;++i){
                        Thread.Sleep(1000);
                        SetPosition(1926, 1771, 163);
                        Thread.Sleep(1400);
                        SetPosition(1930, 1774, 163);
                        Thread.Sleep(1400);
                        
                        Thread.Sleep(6000);
                    } 
                }
        
                public void CancelScript()
                {
                    Game.Close();
                }
            }
        }
