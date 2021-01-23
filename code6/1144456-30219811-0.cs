    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using Shape = DocumentFormat.OpenXml.Presentation.Shape; 
    
    namespace Tester
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pptPath = @"D:\mypresentation.ppt";
                ReadTitles(pptPath);
            }
    
            private static void ReadTitles(string pptPath)
            {
                IList<string> slideTitles = GetSlidesTitles(pptPath);
                Debug.Print("SLIDES TITLES FOR {0}:", pptPath);
                foreach (string slideTitle in slideTitles)
                {
                    Debug.Print("\t {0}", slideTitle);
                }
            }
    
            private static IList<string> GetSlidesTitles(string pptPath)
            {
                string pptxPath = SaveAsPptx(pptPath);
                IList<string> titles = GetSlideTitles(pptxPath);
                try
                {
                    File.Delete(pptxPath);
                    Debug.Print("Temporary pptx file {0} deleted.", pptxPath);
                }
                catch (Exception e)
                {
                    Debug.Print("Error deleting file {0}. ERROR: {1}", pptxPath, e.Message);
                }
                return titles;
            }
    
            private static string SaveAsPptx(string pptPathIn)
            {
    
                Microsoft.Office.Interop.PowerPoint.Application presentationApp = new Microsoft.Office.Interop.PowerPoint.Application();
                string pptxPathOut = null;
                try
                {
    
                    string pptDir = Path.GetDirectoryName(pptPathIn);
                    string pptFileNameOnly = Path.GetFileNameWithoutExtension(pptPathIn);
                    pptxPathOut = Path.Combine(pptDir, pptFileNameOnly + ".pptx");
                    presentationApp.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
    
                    Microsoft.Office.Interop.PowerPoint.Presentations presentations = presentationApp.Presentations;
    
                    Microsoft.Office.Core.MsoTriState readOnly = Microsoft.Office.Core.MsoTriState.msoFalse;
                    Microsoft.Office.Core.MsoTriState untitled = Microsoft.Office.Core.MsoTriState.msoFalse;
                    Microsoft.Office.Core.MsoTriState withWindow = Microsoft.Office.Core.MsoTriState.msoFalse;
    
                    Debug.Print("Opening ppt file {0} ...", pptPathIn);
                    Microsoft.Office.Interop.PowerPoint.Presentation presentation = presentations.Open(pptPathIn, readOnly, untitled, withWindow);
    
                    Debug.Print("Starting creation of pptx from ppt {0}", pptPathIn);
                    presentation.SaveCopyAs(pptxPathOut, PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoFalse);
                    Debug.Print("Successfully created pptx {0} from ppt {1}", pptxPathOut, pptPathIn);
                }
                catch (Exception e)
                {
                    Debug.Print("Error during creating pptx from ppt " + pptPathIn, e);
                }
                finally
                {
                    presentationApp.Quit();
                }
    
                return pptxPathOut;
            }
    
    
            // Get a list of the titles of all the slides in the presentation.
            public static IList<string> GetSlideTitles(string presentationFile)
            {
                // Open the presentation as read-only.
                using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
                {
                    return GetSlideTitles(presentationDocument);
                }
            }
    
            // Get a list of the titles of all the slides in the presentation.
            public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)
            {
                if (presentationDocument == null)
                {
                    throw new ArgumentNullException("presentationDocument");
                }
    
                // Get a PresentationPart object from the PresentationDocument object.
                PresentationPart presentationPart = presentationDocument.PresentationPart;
    
                if (presentationPart != null &&
                    presentationPart.Presentation != null)
                {
                    // Get a Presentation object from the PresentationPart object.
                    Presentation presentation = presentationPart.Presentation;
    
                    if (presentation.SlideIdList != null)
                    {
                        List<string> titlesList = new List<string>();
    
                        // Get the title of each slide in the slide order.
                        foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())
                        {
                            SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
    
                            // Get the slide title.
                            string title = GetSlideTitle(slidePart);
    
                            // An empty title can also be added.
                            titlesList.Add(title);
                        }
    
                        return titlesList;
                    }
    
                }
    
                return null;
            }
    
            // Get the title string of the slide.
            public static string GetSlideTitle(SlidePart slidePart)
            {
                if (slidePart == null)
                {
                    throw new ArgumentNullException("slidePart");
                }
    
                // Declare a paragraph separator.
                string paragraphSeparator = null;
    
                if (slidePart.Slide != null)
                {
                    // Find all the title shapes.
                    var shapes = from shape in slidePart.Slide.Descendants<Shape>()
                                 where IsTitleShape(shape)
                                 select shape;
    
                    StringBuilder paragraphText = new StringBuilder();
    
                    foreach (var shape in shapes)
                    {
                        // Get the text in each paragraph in this shape.
                        foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())
                        {
                            // Add a line break.
                            paragraphText.Append(paragraphSeparator);
    
                            foreach (var text in paragraph.Descendants<D.Text>())
                            {
                                paragraphText.Append(text.Text);
                            }
    
                            paragraphSeparator = "\n";
                        }
                    }
    
                    return paragraphText.ToString();
                }
    
                return string.Empty;
            }
    
            // Determines whether the shape is a title shape.
            private static bool IsTitleShape(Shape shape)
            {
                var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();
                if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)
                {
                    switch ((PlaceholderValues)placeholderShape.Type)
                    {
                        // Any title shape.
                        case PlaceholderValues.Title:
    
                        // A centered title.
                        case PlaceholderValues.CenteredTitle:
                            return true;
    
                        default:
                            return false;
                    }
                }
                return false;
            }
    
        }
    }
