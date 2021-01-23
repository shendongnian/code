    class BigTextRemover : PdfContentStreamEditor
    {
        protected override void Write(PdfContentStreamProcessor processor, PdfLiteral operatorLit, List<PdfObject> operands)
        {
            if (TEXT_SHOWING_OPERATORS.Contains(operatorLit.ToString()))
            {
                Vector fontSizeVector = new Vector(0, Gs().FontSize, 0);
                Matrix textMatrix = (Matrix) textMatrixField.GetValue(this);
                Matrix curentTransformationMatrix = Gs().GetCtm();
                Vector transformedVector = fontSizeVector.Cross(textMatrix).Cross(curentTransformationMatrix);
                float transformedFontSize = transformedVector.Length;
                if (transformedFontSize > 40)
                    return;
            }
            base.Write(processor, operatorLit, operands);
        }
        System.Reflection.FieldInfo textMatrixField = typeof(PdfContentStreamProcessor).GetField("textMatrix", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        List<string> TEXT_SHOWING_OPERATORS = new List<string>{"Tj", "'", "\"", "TJ"};
    }
