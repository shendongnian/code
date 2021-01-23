    using System;
    using System.Collections.Generic;
    using Autodesk.AutoCAD.EditorInput;
    using Autodesk.AutoCAD.Geometry;
    using Autodesk.AutoCAD.ApplicationServices;
    
    namespace EditorUtilities
    {
        /// <summary>
        /// Prompts with the active document ( MdiActiveDocument )
        /// </summary>
        public class EditorHelper : IEditorHelper
        {
            private readonly Editor _editor;
    
            public EditorHelper(Document document)
            {
                _editor = document.Editor;
            }
    
            public PromptEntityResult PromptForObject(string promptMessage, Type allowedType, bool exactMatchOfAllowedType)
            {
                var polyOptions = new PromptEntityOptions(promptMessage);
                polyOptions.SetRejectMessage("Entity is not of type " + allowedType);
                polyOptions.AddAllowedClass(allowedType, exactMatchOfAllowedType);
                var polyResult = _editor.GetEntity(polyOptions);
                return polyResult;
            }
    
            public PromptPointResult PromptForPoint(string promptMessage, bool useDashedLine = false, bool useBasePoint = false, Point3d basePoint = new Point3d(),bool allowNone = true)
            {
                var pointOptions = new PromptPointOptions(promptMessage);
                if (useBasePoint)
                {
                    pointOptions.UseBasePoint = true;
                    pointOptions.BasePoint = basePoint;
                    pointOptions.AllowNone = allowNone;
                }
    
                if (useDashedLine)
                {
                    pointOptions.UseDashedLine = true;
                }
                var pointResult = _editor.GetPoint(pointOptions);
                return pointResult;
            }
    
            public PromptPointResult PromptForPoint(PromptPointOptions promptPointOptions)
            {
                return _editor.GetPoint(promptPointOptions);
            }
    
            public PromptDoubleResult PromptForDouble(string promptMessage, double defaultValue = 0.0)
            {
                var doubleOptions = new PromptDoubleOptions(promptMessage);
                if (Math.Abs(defaultValue - 0.0) > Double.Epsilon)
                {
                    doubleOptions.UseDefaultValue = true;
                    doubleOptions.DefaultValue = defaultValue;
                }
                var promptDoubleResult = _editor.GetDouble(doubleOptions);
                return promptDoubleResult;
            }
    
            public PromptIntegerResult PromptForInteger(string promptMessage)
            {
                var promptIntResult = _editor.GetInteger(promptMessage);
                return promptIntResult;
            }
    
            public PromptResult PromptForKeywordSelection(
                string promptMessage, IEnumerable<string> keywords, bool allowNone, string defaultKeyword = "")
            {
                var promptKeywordOptions = new PromptKeywordOptions(promptMessage) { AllowNone = allowNone };
                foreach (var keyword in keywords)
                {
                    promptKeywordOptions.Keywords.Add(keyword);
                }
                if (defaultKeyword != "")
                {
                    promptKeywordOptions.Keywords.Default = defaultKeyword;
                }
                var keywordResult = _editor.GetKeywords(promptKeywordOptions);
                return keywordResult;
            }
    
            public Point3dCollection PromptForRectangle(out PromptStatus status, string promptMessage)
            {
                var resultRectanglePointCollection = new Point3dCollection();
                var viewCornerPointResult = PromptForPoint(promptMessage);
                var pointPromptStatus = viewCornerPointResult.Status;
                if (viewCornerPointResult.Status == PromptStatus.OK)
                {
                    var rectangleJig = new RectangleJig(viewCornerPointResult.Value);
                    var jigResult = _editor.Drag(rectangleJig);
                    if (jigResult.Status == PromptStatus.OK)
                    {
                        // remove duplicate point at the end of the rectangle
                        var polyline = rectangleJig.Polyline;
                        var viewPolylinePoints = GeometryUtility.GetPointsFromPolyline(polyline);
                        if (viewPolylinePoints.Count == 5)
                        {
                            viewPolylinePoints.RemoveAt(4); // dont know why but true, probably mirror point with the last point
                        }
                    }
                    pointPromptStatus = jigResult.Status;
                }
                status = pointPromptStatus;
                return resultRectanglePointCollection;
            }
    
            public PromptSelectionResult PromptForSelection(string promptMessage = null, SelectionFilter filter = null)
            {
                var selectionOptions = new PromptSelectionOptions { MessageForAdding = promptMessage };
                var selectionResult = String.IsNullOrEmpty(promptMessage) ? _editor.SelectAll(filter) : _editor.GetSelection(selectionOptions, filter);
                return selectionResult;
            }
    
            public PromptSelectionResult PromptForSelection(PromptSelectionOptions promptSelectionOptions,SelectionFilter filter = null)
            {
                return _editor.GetSelection(promptSelectionOptions, filter);
            }
    
            public void WriteMessage(string message)
            {
                _editor.WriteMessage(message);
            }
    
            public void DrawVector(Point3d from, Point3d to, int color, bool drawHighlighted)
            {
                _editor.DrawVector(from, to, color, drawHighlighted);
            }
        }
    }
