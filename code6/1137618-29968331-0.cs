    public static C.ValueAxis CreateAxis(C.ScatterChart chart, UInt32Value id, DocumentFormat.OpenXml.Drawing.Charts.AxisPositionValues position)
    {
        chart.Append(new C.AxisId() { Val = id });
    
        C.ValueAxis valueAxis = new C.ValueAxis();
        C.AxisId axisID = new C.AxisId() { Val = id };
        C.Scaling scaling = new C.Scaling();
        C.Orientation orientation = new C.Orientation() { Val = C.OrientationValues.MinMax };
        scaling.Append(orientation);
        C.Delete deleteProperty = new C.Delete() { Val = false };
        C.AxisPosition axisPosition = new C.AxisPosition() { Val = position };
    
    
        C.MajorGridlines majorGridlines = new C.MajorGridlines(
                new C.ChartShapeProperties(
                    new A.Outline(new A.SolidFill(
                        new A.SchemeColor(
                            new A.LuminanceModulation() { Val = 50000 },
                            new A.LuminanceOffset() { Val = 50000 }
                        ) { Val = A.SchemeColorValues.Text1 }
                    ))
                )
        );
    
        C.CrossingAxis crossingAxis = new C.CrossingAxis() { Val = id };
        valueAxis.Append(axisID);
        valueAxis.Append(scaling);
        valueAxis.Append(deleteProperty);
        valueAxis.Append(axisPosition);
        valueAxis.Append(majorGridlines);
        valueAxis.Append(crossingAxis);
        return valueAxis;
    }
    private static void CreateChart(ChartPart chartPart, params C.ScatterChartSeries[] series)
    {
        C.ChartSpace chartSpace = new C.ChartSpace();
        chartSpace.AddNamespaceDeclaration("c", "http://schemas.openxmlformats.org/drawingml/2006/chart");
        chartSpace.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
        chartSpace.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
        C.Date1904 date19041 = new C.Date1904() { Val = false };
    
    
        AlternateContentChoice alternateContentChoice2 = new AlternateContentChoice() { Requires = "c14" };
        alternateContentChoice2.AddNamespaceDeclaration("c14", "http://schemas.microsoft.com/office/drawing/2007/8/2/chart");
        C14.Style style1 = new C14.Style() { Val = 102 };
    
        alternateContentChoice2.Append(style1);
    
        AlternateContentFallback alternateContentFallback1 = new AlternateContentFallback();
        C.Style style2 = new C.Style() { Val = 2 };
    
        alternateContentFallback1.Append(style2);
    
    
        C.Chart mainChart = new C.Chart();
    
        C.Title chartTitle = new C.Title();
        C.Layout layout1 = new C.Layout();
        C.Overlay overlay1 = new C.Overlay() { Val = false };
    
        C.ChartShapeProperties chartShapeProperties1 = new C.ChartShapeProperties();
        A.NoFill noFill1 = new A.NoFill();
    
        A.Outline outline4 = new A.Outline();
        A.NoFill noFill2 = new A.NoFill();
    
        outline4.Append(noFill2);
        A.EffectList effectList4 = new A.EffectList();
    
        chartShapeProperties1.Append(noFill1);
        chartShapeProperties1.Append(outline4);
        chartShapeProperties1.Append(effectList4);
    
        C.TextProperties textProperties1 = new C.TextProperties();
        A.BodyProperties bodyProperties1 = new A.BodyProperties() { Rotation = 0, UseParagraphSpacing = true, VerticalOverflow = A.TextVerticalOverflowValues.Ellipsis, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.Square, Anchor = A.TextAnchoringTypeValues.Center, AnchorCenter = true };
        A.ListStyle listStyle1 = new A.ListStyle();
    
        A.Paragraph paragraph1 = new A.Paragraph();
    
        A.ParagraphProperties paragraphProperties1 = new A.ParagraphProperties();
    
        A.DefaultRunProperties defaultRunProperties1 = new A.DefaultRunProperties() { FontSize = 1400, Bold = false, Italic = false, Underline = A.TextUnderlineValues.None, Strike = A.TextStrikeValues.NoStrike, Kerning = 1200, Spacing = 0, Baseline = 0 };
    
        A.SolidFill solidFill7 = new A.SolidFill();
    
        A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
        A.LuminanceModulation luminanceModulation9 = new A.LuminanceModulation() { Val = 65000 };
        A.LuminanceOffset luminanceOffset1 = new A.LuminanceOffset() { Val = 35000 };
    
        schemeColor16.Append(luminanceModulation9);
        schemeColor16.Append(luminanceOffset1);
    
        solidFill7.Append(schemeColor16);
        A.LatinFont latinFont3 = new A.LatinFont() { Typeface = "+mn-lt" };
        A.EastAsianFont eastAsianFont3 = new A.EastAsianFont() { Typeface = "+mn-ea" };
        A.ComplexScriptFont complexScriptFont3 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };
    
        defaultRunProperties1.Append(solidFill7);
        defaultRunProperties1.Append(latinFont3);
        defaultRunProperties1.Append(eastAsianFont3);
        defaultRunProperties1.Append(complexScriptFont3);
    
        paragraphProperties1.Append(defaultRunProperties1);
        A.EndParagraphRunProperties endParagraphRunProperties1 = new A.EndParagraphRunProperties() { Language = "en-US" };
    
        paragraph1.Append(paragraphProperties1);
        paragraph1.Append(endParagraphRunProperties1);
    
        textProperties1.Append(bodyProperties1);
        textProperties1.Append(listStyle1);
        textProperties1.Append(paragraph1);
    
        chartTitle.Append(layout1);
        chartTitle.Append(overlay1);
        chartTitle.Append(chartShapeProperties1);
        chartTitle.Append(textProperties1);
    
        C.PlotArea plotArea1 = new C.PlotArea();
    
        C.ScatterChart scatterChart1 = new C.ScatterChart();
        C.ScatterStyle scatterStyle1 = new C.ScatterStyle() { Val = C.ScatterStyleValues.LineMarker };
        C.VaryColors varyColors1 = new C.VaryColors() { Val = false };
    
    
    
    
        scatterChart1.Append(scatterStyle1);
        scatterChart1.Append(varyColors1);
    
    
        //DS (Modified): <<
    
        foreach (var cSeries in series)
        {
            scatterChart1.Append(cSeries);
        }
    
        scatterChart1.Append(new C.DataLabels(
            new C.Delete() { Val = true }
        ));
    
        C.ValueAxis valueAxis1 = CreateAxis(scatterChart1, 1848291296U, DocumentFormat.OpenXml.Drawing.Charts.AxisPositionValues.Bottom);
        C.ValueAxis valueAxis2 = CreateAxis(scatterChart1, 1848283680U, DocumentFormat.OpenXml.Drawing.Charts.AxisPositionValues.Left);
    
        //>>
    
        plotArea1.Append(scatterChart1);
        plotArea1.Append(valueAxis1);
        plotArea1.Append(valueAxis2);
    
        mainChart.Append(chartTitle);
        mainChart.Append(plotArea1);
    
    
        chartSpace.Append(date19041);
        chartSpace.Append(mainChart);
        chartPart.ChartSpace = chartSpace;
    }
    
    public static C.ScatterChartSeries CreateSeries(UInt32Value index, string xFormula, string yFormula, C.Marker marker)
    {
        C.ScatterChartSeries scatterChartSeries2 = new C.ScatterChartSeries(
            new C.Index() { Val = index },
            new C.Order() { Val = index }
        );
        scatterChartSeries2.Append(marker);
    
        scatterChartSeries2.Append(
            new C.XValues(
            new C.NumberReference(
                    new C.Formula(xFormula)
            )),
    
            new C.YValues(
            new C.NumberReference(
                    new C.Formula(yFormula)
            ))
        );
    
        scatterChartSeries2.Append(new C.Smooth() { Val = false });
        return scatterChartSeries2;
    }
    
    public static C.Marker CreateMarker(C.MarkerStyleValues makerStyle, ByteValue size, A.SchemeColorValues markerColor)
    {
    
        return new C.Marker(
            new C.Symbol() { Val = makerStyle },
            new C.Size() { Val = size },
            new C.ChartShapeProperties(
                new A.SolidFill(
                        new A.SchemeColor() { Val = markerColor }
                    ),
                    new A.Outline(
                        new A.SolidFill(
                            new A.SchemeColor() { Val = markerColor }
                        )
                    ) { Width = 9525 }
            )
        );
    }
    
    
