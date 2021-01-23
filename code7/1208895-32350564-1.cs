        private static OpenXmlElement CreateImageContainer(OpenXmlPart part, string relationshipId, string imageName, int widthPixels, int heightPixels)
        {
            long widthEMU = (widthPixels * 914400L) / 96L;
            long heightEMU = (heightPixels * 914400L) / 96L;
            var element =
                        new Paragraph(
                            new Run(
                                new RunProperties(
                                    new NoProof()),
                                new Drawing(
                                    new wp.Inline(
                                        new wp.Extent() { Cx = widthEMU, Cy = heightEMU },
                                        new wp.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 0", Description = imageName },
                                        new wp.NonVisualGraphicFrameDrawingProperties(
                                            new a.GraphicFrameLocks() { NoChangeAspect = true }),
                                        new a.Graphic(
                                            new a.GraphicData(
                                                new pic.Picture(
                                                    new pic.NonVisualPictureProperties(
                                                        new pic.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = imageName },
                                                        new pic.NonVisualPictureDrawingProperties()),
                                                    new pic.BlipFill(
                                                        new a.Blip() { Embed = relationshipId },
                                                        new a.Stretch(
                                                            new a.FillRectangle())),
                                                    new pic.ShapeProperties(
                                                        new a.Transform2D(
                                                            new a.Offset() { X = 0L, Y = 0L },
                                                            new a.Extents() { Cx = widthEMU, Cy = heightEMU }),
                                                        new a.PresetGeometry(
                                                            new a.AdjustValueList()
                                                        ) { Preset = a.ShapeTypeValues.Rectangle }))
                                            ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                    ) { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U }))
                        );
            return element;
        }
