    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using DocumentFormat.OpenXml;
    using P = DocumentFormat.OpenXml.Presentation;
    using A = DocumentFormat.OpenXml.Drawing;
    
    using DocumentFormat.OpenXml.ExtendedProperties;
    
    
    namespace AddNoteToPPT
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filePath = @"D:\Projects\Task\Documents\OpenXML_2 - Copy.pptx";
                AddNote(filePath, 0);
            }
    
    
            private static void GenerateSlidePart2Content(SlidePart slidePart2)
            {
    
            }
            public static void AddNote(string docName, int index)
            {
                try
                {
                    string relId = "rId" + (index + 1);
                    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))
                    {
                        PresentationPart part = ppt.PresentationPart;
                        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
    
                        relId = (slideIds[index] as SlideId).RelationshipId;
                    }
                    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))
                    {
    
                        PresentationPart presentationPart1 = ppt.PresentationPart;
                        SlidePart slidePart2 = (SlidePart)presentationPart1.GetPartById(relId);
                        NotesSlidePart notesSlidePart1;
                        string existingSlideNote = "";
    
                        if (slidePart2.NotesSlidePart != null)
                        { 
                            //Appened new note to existing note.
                            existingSlideNote = slidePart2.NotesSlidePart.NotesSlide.InnerText + "\n";
                            var val = (NotesSlidePart)slidePart2.GetPartById(relId);
                            notesSlidePart1 = slidePart2.AddPart<NotesSlidePart>(val, relId);
                        }
                        else
                        {  
                            //Add a new noteto a slide.                      
                            notesSlidePart1 = slidePart2.AddNewPart<NotesSlidePart>(relId);
                        }
    
                        NotesSlide notesSlide = new NotesSlide(
                            new CommonSlideData(new ShapeTree(
                              new P.NonVisualGroupShapeProperties(
                                new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
                                new P.NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                                new GroupShapeProperties(new A.TransformGroup()),
                                new P.Shape(
                                    new P.NonVisualShapeProperties(
                                        new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Slide Image Placeholder 1" },
                                        new P.NonVisualShapeDrawingProperties(new A.ShapeLocks() { NoGrouping = true, NoRotation = true, NoChangeAspect = true }),
                                        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.SlideImage })),
                                    new P.ShapeProperties()),
                                new P.Shape(
                                    new P.NonVisualShapeProperties(
                                        new P.NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Notes Placeholder 2" },
                                        new P.NonVisualShapeDrawingProperties(new A.ShapeLocks() { NoGrouping = true }),
                                        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U })),
                                    new P.ShapeProperties(),
                                    new P.TextBody(
                                        new A.BodyProperties(),
                                        new A.ListStyle(),
                                        new A.Paragraph(
                                            new A.Run(
                                                new A.RunProperties() { Language = "en-US", Dirty = false },
                                                new A.Text() { Text = existingSlideNote + "Value Updated" }),
                                            new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false }))
                                        ))),
                            new ColorMapOverride(new A.MasterColorMapping()));
    
                        notesSlidePart1.NotesSlide = notesSlide;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                    Console.ReadLine();
                }
            }
        }
    }
