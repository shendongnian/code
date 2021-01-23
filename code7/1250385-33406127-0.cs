    using DocumentFormat.OpenXml.Wordprocessing;
    using DocumentFormat.OpenXml;
    using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
    using A = DocumentFormat.OpenXml.Drawing;
    using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
    
    namespace GeneratedCode
    {
        public class GeneratedClass
        {
            // Creates an Body instance and adds its children.
            public Body GenerateBody()
            {
                Body body1 = new Body();
            Paragraph paragraph1 = new Paragraph(){ RsidParagraphAddition = "00970886", RsidRunAdditionDefault = "00164292" };
            Run run1 = new Run();
            RunProperties runProperties1 = new RunProperties();
            NoProof noProof1 = new NoProof();
            runProperties1.Append(noProof1);
            Drawing drawing1 = new Drawing();
            Wp.Inline inline1 = new Wp.Inline(){ DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U };
            Wp.Extent extent1 = new Wp.Extent(){ Cx = 2009775L, Cy = 2276475L };
            Wp.EffectExtent effectExtent1 = new Wp.EffectExtent(){ LeftEdge = 19050L, TopEdge = 0L, RightEdge = 9525L, BottomEdge = 0L };
            Wp.DocProperties docProperties1 = new Wp.DocProperties(){ Id = (UInt32Value)1U, Name = "Picture 0", Description = "Authentication.jpg" };
            Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new Wp.NonVisualGraphicFrameDrawingProperties();
            A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks(){ NoChangeAspect = true };
            graphicFrameLocks1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);
            A.Graphic graphic1 = new A.Graphic();
            graphic1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            A.GraphicData graphicData1 = new A.GraphicData(){ Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" };
            Pic.Picture picture1 = new Pic.Picture();
            picture1.AddNamespaceDeclaration("pic", "http://schemas.openxmlformats.org/drawingml/2006/picture");
            Pic.NonVisualPictureProperties nonVisualPictureProperties1 = new Pic.NonVisualPictureProperties();
            Pic.NonVisualDrawingProperties nonVisualDrawingProperties1 = new Pic.NonVisualDrawingProperties(){ Id = (UInt32Value)0U, Name = "Authentication.jpg" };
            Pic.NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties1 = new Pic.NonVisualPictureDrawingProperties();
            nonVisualPictureProperties1.Append(nonVisualDrawingProperties1);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);
            Pic.BlipFill blipFill1 = new Pic.BlipFill();
            A.Blip blip1 = new A.Blip(){ Embed = "rId6" };
            A.Stretch stretch1 = new A.Stretch();
            A.FillRectangle fillRectangle1 = new A.FillRectangle();
            stretch1.Append(fillRectangle1);
            blipFill1.Append(blip1);
            blipFill1.Append(stretch1);
            Pic.ShapeProperties shapeProperties1 = new Pic.ShapeProperties();
            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset1 = new A.Offset(){ X = 0L, Y = 0L };
            A.Extents extents1 = new A.Extents(){ Cx = 2009775L, Cy = 2276475L };
            transform2D1.Append(offset1);
            transform2D1.Append(extents1);
            A.PresetGeometry presetGeometry1 = new A.PresetGeometry(){ Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();
            presetGeometry1.Append(adjustValueList1);
            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            picture1.Append(nonVisualPictureProperties1);
            picture1.Append(blipFill1);
            picture1.Append(shapeProperties1);
            graphicData1.Append(picture1);
            graphic1.Append(graphicData1);
            inline1.Append(extent1);
            inline1.Append(effectExtent1);
            inline1.Append(docProperties1);
            inline1.Append(nonVisualGraphicFrameDrawingProperties1);
            inline1.Append(graphic1);
            drawing1.Append(inline1);
            run1.Append(runProperties1);
            run1.Append(drawing1);
            paragraph1.Append(run1);
            SectionProperties sectionProperties1 = new SectionProperties(){ RsidR = "00970886" };
            HeaderReference headerReference1 = new HeaderReference(){ Type = HeaderFooterValues.Even, Id = "rId7" };
            HeaderReference headerReference2 = new HeaderReference(){ Type = HeaderFooterValues.Default, Id = "rId8" };
            FooterReference footerReference1 = new FooterReference(){ Type = HeaderFooterValues.Even, Id = "rId9" };
            FooterReference footerReference2 = new FooterReference(){ Type = HeaderFooterValues.Default, Id = "rId10" };
            HeaderReference headerReference3 = new HeaderReference(){ Type = HeaderFooterValues.First, Id = "rId11" };
            FooterReference footerReference3 = new FooterReference(){ Type = HeaderFooterValues.First, Id = "rId12" };
            PageSize pageSize1 = new PageSize(){ Width = (UInt32Value)12240U, Height = (UInt32Value)15840U };
            PageMargin pageMargin1 = new PageMargin(){ Top = 1440, Right = (UInt32Value)1440U, Bottom = 1440, Left = (UInt32Value)1440U, Header = (UInt32Value)720U, Footer = (UInt32Value)720U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns(){ Space = "720" };
            DocGrid docGrid1 = new DocGrid(){ LinePitch = 360 };
            sectionProperties1.Append(headerReference1);
            sectionProperties1.Append(headerReference2);
            sectionProperties1.Append(footerReference1);
            sectionProperties1.Append(footerReference2);
            sectionProperties1.Append(headerReference3);
            sectionProperties1.Append(footerReference3);
            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(docGrid1);
            body1.Append(paragraph1);
            body1.Append(sectionProperties1);
            return body1;
        }
    }
}
