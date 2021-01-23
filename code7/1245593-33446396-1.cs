    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            Random rand = new Random();
    
            Stopwatch stopwatch;
            long frameCounter = 0;
    
            GlyphTypeface glyphTypeface;
            double renderingEmSize, advanceWidth, advanceHeight;
            Point baselineOrigin;
    
            public MainWindow()
            {
                InitializeComponent();
    
                new Typeface("Consolas").TryGetGlyphTypeface(out this.glyphTypeface);
                this.renderingEmSize = 10;
                this.advanceWidth = this.glyphTypeface.AdvanceWidths[0] * this.renderingEmSize;
                this.advanceHeight = this.glyphTypeface.Height * this.renderingEmSize;
                this.baselineOrigin = new Point(0, this.glyphTypeface.Baseline * this.renderingEmSize);
    
                CompositionTarget.Rendering += CompositionTarget_Rendering;
    
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += timer_Tick;
                timer.Start();
            }
    
            void CompositionTarget_Rendering(object sender, EventArgs e)
            {
                if (this.stopwatch == null)
                    this.stopwatch = Stopwatch.StartNew();
    
                ++this.frameCounter;
    
                this.drawingImage.Drawing = this.Render();
            }
    
            string GenerateRandomString(int length)
            {
                var chars = new char[length];
                for (int i = 0; i < chars.Length; ++i)
                    chars[i] = (char)rand.Next('A', 'Z' + 1);
    
                return new string(chars);
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                var seconds = this.stopwatch.Elapsed.TotalSeconds;
                Trace.WriteLine((long)(this.frameCounter / seconds));
    
                if (seconds > 10)
                {
                    this.stopwatch.Restart();
                    this.frameCounter = 0;
                }
            }
    
            private Drawing Render()
            {
                var lines = new string[30];
                for (int i = 0; i < lines.Length; ++i)
                    lines[i] = GenerateRandomString(100);
    
                var drawing = new DrawingGroup();
                using (var drawingContext = drawing.Open())
                {
                    // TODO: draw rectangles which represent background.
    
                    // TODO: group of glyphs which has the same color should be drawn together.
                    // Following code draws all glyphs in Red color.
                    var glyphRun = ConvertTextLinesToGlyphRun(this.glyphTypeface, this.renderingEmSize, this.advanceWidth, this.advanceHeight, this.baselineOrigin, lines);
                    drawingContext.DrawGlyphRun(Brushes.Red, glyphRun);
                }
    
                return drawing;
            }
    
            static GlyphRun ConvertTextLinesToGlyphRun(GlyphTypeface glyphTypeface, double renderingEmSize, double advanceWidth, double advanceHeight, Point baselineOrigin, string[] lines)
            {
                var glyphIndices = new List<ushort>();
                var advanceWidths = new List<double>();
                var glyphOffsets = new List<Point>();
    
                var y = baselineOrigin.Y;
                for (int i = 0; i < lines.Length; ++i)
                {
                    var line = lines[i];
    
                    var x = baselineOrigin.X;
                    for (int j = 0; j < line.Length; ++j)
                    {
                        var glyphIndex = glyphTypeface.CharacterToGlyphMap[line[j]];
                        glyphIndices.Add(glyphIndex);
                        advanceWidths.Add(0);
                        glyphOffsets.Add(new Point(x, y));
    
                        x += advanceWidth;
    
                    }
    
                    y += advanceHeight;
                }
    
                return new GlyphRun(
                    glyphTypeface,
                    0,
                    false,
                    renderingEmSize,
                    glyphIndices,
                    baselineOrigin,
                    advanceWidths,
                    glyphOffsets,
                    null,
                    null,
                    null,
                    null,
                    null);
            }
        }
    }
