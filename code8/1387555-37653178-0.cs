    using System;
    using System.Windows;
    using XPression;
    
    namespace mynamespace
    {
        public partial class MainWindow : Window
        {
            private xpEngine engine;
            private xpOutputFrameBuffer outputFrameBuffer;
            public MainWindow()
            {
                InitializeComponent();
                engine = new xpEngine();
                if (engine.GetOutputFrameBuffer(0, out outputFrameBuffer))
                {
                    outputFrameBuffer.OnSceneState += OutputFrameBuffer_OnSceneState;
                }
            }
    
            private void OutputFrameBuffer_OnSceneState(xpScene Scene, int State)
            {
                Console.WriteLine("Scene: " + Scene.Name + " State: " + State);
            }
        }
    }
