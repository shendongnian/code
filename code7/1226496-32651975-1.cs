    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace SmoothAnimationDemo
    {
        public partial class Form1 : Form
        {
            // check every x frames, calculate fps, adjust x
            private readonly FrameInfo _frameInfo = new FrameInfo(DateTime.Now);
            private readonly List<Animation> _animations = new List<Animation>();
    
            public Form1()
            {
                InitializeComponent();
    
                this.DoubleBuffered = true;
    
                FrameInfoVisible = false; // Set to true if needed. 
                RegisterAnimation(new Snake(this));
            }
    
            public bool FrameInfoVisible { get; set; }
    
            public void RegisterAnimation(Animation animation)
            {
                _animations.Add(animation);
            }
    
            private int _skipframes = 1;
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                // Skip updating if needed.
                if (_skipframes > 0)
                {
                    _skipframes--;
                }
                else
                {
                    _frameInfo.Update();
                    foreach (var animation in _animations)
                        animation.UpdatePositions(_frameInfo);
    
                    _skipframes = 0; // adjust to skip frames or leave at 0 to not skip frames. 
                }
    
                // init drawing
                var gfx = e.Graphics;
                gfx.Clear(Color.Black);
    
                // draw each frame. 
                foreach (var animation in _animations)
                {
                    animation.Draw(gfx);
                    gfx.ResetTransform(); // in case the animation used transform methods.
                }
    
                // draw timer info on top
                if (FrameInfoVisible)
                    _frameInfo.Draw(gfx);
    
                // wait till a certain time has passed before drawing again. 
                //Thread.Sleep(10);
                Invalidate(); // ensure new paint soon
            }
        }
    
        /// <summary>
        /// abstract base class for animations.
        /// An animation contains two methods. First one used for updating animation data, eg positions.
        /// Second one used for drawing the data onto a graphics object.
        /// </summary>
        public abstract class Animation : IDrawable, IAnimatable
        {
            public abstract void Draw(Graphics gfx);
    
            public abstract void UpdatePositions(FrameInfo frameInfo);
        }
    
        /// <summary>
        /// Contains info about our frames
        /// </summary>
        public class FrameInfo
        {
            public DateTime FirstFrameTime { get; set; }
            public DateTime PrevFrameTime { get; set; }
            public DateTime FrameTime { get; set; }
            public int FrameCount { get; set; }
            public double FramesPerSecond { get; set; }
    
            public FrameInfo(DateTime now)
            {
                FirstFrameTime = now;
            }
    
            public void Update()
            {
                PrevFrameTime = FrameTime;
                FrameTime = DateTime.Now;
                FrameCount++;
                FramesPerSecond = 1000.0 / (FrameTime - PrevFrameTime).TotalMilliseconds;
            }
    
            public void Draw(Graphics gfx)
            {
                gfx.DrawString("Frame time", SystemFonts.DefaultFont, Brushes.Black, 0, 0);
                gfx.DrawString(String.Format(": {0:hh:mm:ss.zzzz}", FrameTime - FirstFrameTime), SystemFonts.DefaultFont, Brushes.Black, 70, 0);
                gfx.DrawString("Frame", SystemFonts.DefaultFont, Brushes.Black, 0, 16);
                gfx.DrawString(": " + FrameCount, SystemFonts.DefaultFont, Brushes.Black, 70, 16);
                gfx.DrawString("FPS", SystemFonts.DefaultFont, Brushes.Black, 0, 32);
                gfx.DrawString(": " + FramesPerSecond, SystemFonts.DefaultFont, Brushes.Black, 70, 32);
            }
        }
    
        internal interface IAnimatable
        {
            void UpdatePositions(FrameInfo frameInfo);
        }
    
        internal interface IDrawable
        {
            void Draw(Graphics gfx);
        }
    
        /// <summary>
        /// Animation module
        /// </summary>
        internal class Snake : Animation
        {
            public Snake(Control form)
            {
                form.KeyDown += form_KeyDown;
                form.KeyUp += form_KeyUp;
            }
    
            readonly Dictionary<Keys, bool> _keyMap = new Dictionary<Keys, bool>
            {
                { Keys.Up, false },
                { Keys.Down, false },
                { Keys.Left, false },
                { Keys.Right, false }
            };
    
            void form_KeyUp(object sender, KeyEventArgs e)
            {
                if (_keyMap.ContainsKey(e.KeyCode))
                    _keyMap[e.KeyCode] = false;
            }
    
            void form_KeyDown(object sender, KeyEventArgs e)
            {
                if (_keyMap.ContainsKey(e.KeyCode))
                    _keyMap[e.KeyCode] = true;
            }
    
            private PointF _headPos = new PointF(100.0f, 100.0f);
    
            public override void UpdatePositions(FrameInfo info)
            {
                // Ensure that the motion is moving at a 
                var speed = 100; // 100 units within 1 second
                var perc = (double)(info.FrameTime - info.PrevFrameTime).TotalMilliseconds / 1000;
                var displaceAmount = (float)(speed * perc);
    
                if (_keyMap[Keys.Up])
                    _headPos.Y -= displaceAmount;
                if (_keyMap[Keys.Down])
                    _headPos.Y += displaceAmount;
                if (_keyMap[Keys.Right])
                    _headPos.X += displaceAmount;
                if (_keyMap[Keys.Left])
                    _headPos.X -= displaceAmount;
            }
    
            public override void Draw(Graphics gfx)
            {
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.DrawString(String.Format("[{0},{1}]", _headPos.X, _headPos.Y), SystemFonts.DefaultFont, Brushes.Black, 0.0f, 48.0f);
                gfx.DrawEllipse(Pens.White, _headPos.X, _headPos.Y, 10.0f, 10.0f);
            }
        }
    
    }
