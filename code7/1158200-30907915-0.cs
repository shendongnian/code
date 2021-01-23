        /// <summary>
        /// Add a new shape to the worksheet
        /// </summary>
        /// <param name="Name">Name</param>
        /// <param name="Source">Source shape</param>
        /// <returns>The shape object</returns>
        public ExcelShape AddShape(string Name, ExcelShape Source)
        {
            if (Worksheet is ExcelChartsheet && _drawings.Count > 0)
            {
                throw new InvalidOperationException("Chart worksheets can't have more than one drawing");
            }
            if (_drawingNames.ContainsKey(Name))
            {
                throw new Exception("Name already exists in the drawings collection");
            }
            XmlElement drawNode = CreateDrawingXml();
            drawNode.InnerXml = Source.TopNode.InnerXml;
            ExcelShape shape = new ExcelShape(this, drawNode);
            shape.Name = Name;
            shape.Style = Source.Style;
            _drawings.Add(shape);
            _drawingNames.Add(Name, _drawings.Count - 1);
            return shape;
        }
