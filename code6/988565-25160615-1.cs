    protected void CreateBitmap(int Width, int Height) 
    { 
        // Create the background bitmap 
        BackGroundBitmap = new Bitmap(Width, Height);           
        // Set the background bitmap to be the Form's background image 
        BackgroundImage = BackGroundBitmap; 
    } 
    private void button1_Click(object sender, EventArgs e)
    {
        CreateBitmap(500, 500);
        string zee1, zee2, zee3, zee4; // Publically declared strings
        float m1, n1, m2, n2; // publically declared integers
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            using (StreamReader Reader = new StreamReader(openFileDialog1.FileName, true))
            {
                zee1 = Reader.ReadLine();
                m1 = float.Parse(zee1);
                zee2 = Reader.ReadLine();
                n1 = float.Parse(zee2);
                zee3 = Reader.ReadLine();
                m2 = float.Parse(zee3);
                zee4 = Reader.ReadLine();
                n2 = float.Parse(zee4);
                                                        
                Graphics gra = Graphics.FromImage(BackGroundBitmap);
                var Teera = new Pen(Color.Black, 5);
                var Nanga1 = new PointF(m1, n1);
                var Nanga2 = new PointF(m2, n2);
                gra.DrawLine(Teera, Nanga1, Nanga2);
                BackGroundBitmap.Save("result.jpg");
                BackgroundImage = Image.FromFile("result.jpg");
                    
                Teera.Dispose();
            }
        }
    }
