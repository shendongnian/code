        private void SaveByteArrayToFile(byte[] byteArray)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            string filepath = "";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filepath += dialog.SelectedPath;
                System.Windows.MessageBox.Show(filepath);
            }
            filepath += "Signature.txt";
            MyCustomStrokes customStrokes = new MyCustomStrokes();
            customStrokes.StrokeCollection = new Point[myInkCanvas.Strokes.Count][];
            for (int i = 0; i < myInkCanvas.Strokes.Count; i++)
            {
                customStrokes.StrokeCollection[i] = 
                new Point[this.myInkCanvas.Strokes[i].StylusPoints.Count];
                for (int j = 0; j < myInkCanvas.Strokes[i].StylusPoints.Count; j++)
                {
                    customStrokes.StrokeCollection[i][j] = new Point();
                    customStrokes.StrokeCollection[i][j].X = 
                                      myInkCanvas.Strokes[i].StylusPoints[j].X;
                    customStrokes.StrokeCollection[i][j].Y = 
                                      myInkCanvas.Strokes[i].StylusPoints[j].Y;
                }
            }
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, customStrokes);
            File.WriteAllBytes(filepath, Encrypt(ms.GetBuffer()));
        }
       private void ReadByteArrayFromFile(string Chosen_File)
        {
            
            byte[] bytesFromFile = File.ReadAllBytes(Chosen_File);
            byte[] decryptedBytes = Decrypt(bytesFromFile);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(decryptedBytes);
                MyCustomStrokes customStrokes = bf.Deserialize(ms) as MyCustomStrokes;
                for(int i = 0; i < customStrokes.StrokeCollection.Length; i++)
                {
                    if(customStrokes.StrokeCollection[i] != null)
                    {
                        StylusPointCollection stylusCollection = new
                          StylusPointCollection(customStrokes.StrokeCollection[i]);
                        Stroke stroke = new Stroke(stylusCollection);
                        StrokeCollection strokes = new StrokeCollection();
                        strokes.Add(stroke);
                        this.MyInkPresenter.Strokes.Add(strokes);
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    [Serializable]
    public sealed class MyCustomStrokes
    {
        public MyCustomStrokes() { }
        /// <SUMMARY>
        /// The first index is for the stroke no.
        /// The second index is for the keep the 2D point of the Stroke.
        /// </SUMMARY>
        public Point[][] StrokeCollection;
    }
