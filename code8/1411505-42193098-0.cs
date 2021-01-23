    using NetOffice.OfficeApi.Enums;
    using NetOffice.PowerPointApi.Enums;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using PowerPoint = NetOffice.PowerPointApi;
    namespace PlayPowerPoint
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var app = new PowerPoint.Application())
                {
                    var presentation = app.Presentations.Open(Path.GetFullPath("Test.pptx"), MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoTrue);
                    var slideShowSettings = presentation.SlideShowSettings;
                    slideShowSettings.StartingSlide = 2;
                    slideShowSettings.EndingSlide = 4;
                    slideShowSettings.RangeType = PpSlideShowRangeType.ppShowSlideRange;
                    slideShowSettings.AdvanceMode = PpSlideShowAdvanceMode.ppSlideShowManualAdvance;
                    slideShowSettings.Run();
                    var slideShowView = presentation.SlideShowWindow.View;
                    while (slideShowView.CurrentShowPosition < slideShowSettings.EndingSlide)
                    {
                        Thread.Sleep(2000);
                        slideShowView.Next();
                    }
                    presentation.Saved = MsoTriState.msoTrue;
                    presentation.Close();
                    app.Quit();
                }
            }
        }
    }
