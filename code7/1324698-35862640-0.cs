        using System;
        using GLib;
        using SkiaSharp;
        using Gtk;
        
        namespace SkiaSharpExample
        {
            class CCDrawingArea : DrawingArea
            {
                protected override bool OnDrawn(Cairo.Context cr)
                {
                    const int width = 100;
                    const int height = 100;
        
                    using (var bitmap = new SKBitmap(width, height, SKColorType.N_32, SKAlphaType.Premul))
                    {
                        IntPtr len;
                        using (var skSurface = SKSurface.Create(bitmap.Info.Width, bitmap.Info.Height, SKColorType.N_32, SKAlphaType.Premul, bitmap.GetPixels(out len), bitmap.Info.RowBytes))
                        {
                            var canvas = skSurface.Canvas;
                            canvas.Clear(SKColors.White);
        
                            using (var paint = new SKPaint())
                            {
                                paint.StrokeWidth = 4;
                                paint.Color = new SKColor(0x2c, 0x3e, 0x50);
        
                                var rect = new SKRect(10, 10, 50, 50);
                                canvas.DrawRect(rect, paint);
                            }
        
                            Cairo.Surface surface = new Cairo.ImageSurface(
                                bitmap.GetPixels(out len),
                                Cairo.Format.Argb32,
                                bitmap.Width, bitmap.Height,
                                bitmap.Width * 4);
        
        
                            surface.MarkDirty();
                            cr.SetSourceSurface(surface, 0, 0);
                            cr.Paint();
                        }
                    }
        
                    return true;
                }
            }
        
            class MainClass
            {
                public static void Main(string[] args)
                {
                    ExceptionManager.UnhandledException += delegate(UnhandledExceptionArgs expArgs)
                    {
                        Console.WriteLine(expArgs.ExceptionObject.ToString());
                        expArgs.ExitApplication = true;
                    };
        
                    Gtk.Application.Init();
        
                    var window = new Window("Hello Skia World");
                    window.SetDefaultSize(1024, 800);
                    window.SetPosition(WindowPosition.Center);
                    window.DeleteEvent += delegate
                    {
                        Gtk.Application.Quit();
                    };
        
                    var darea = new CCDrawingArea();
                    window.Add(darea);
        
                    window.ShowAll();
        
                    Gtk.Application.Run();
                }
        
                void OnException(object o, UnhandledExceptionArgs args)
                {
        
                }
            }
        }
