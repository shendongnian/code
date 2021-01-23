    List<SolidBrush> seatBrushes = new List<SolidBrush>() 
        { (SolidBrush)Brushes.Red, (SolidBrush)Brushes.Green  /*..*/ };
    public Bitmap bmp_Display { get; set; }
    public Bitmap bmp_Buffer { get; set; }
    public class Seat  
    {
        public string Name { get; set; }
        public int State { get; set; }
        public Point Location { get; set; } 
        //...
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
            if ((worker.CancellationPending == true))
            {  e.Cancel = true;  }
            else
            {
                // get the seat data..
                List<Seat> seats = getSeatData();
                if (seats.Count > 0)
                {
                    Graphics G = Graphics.FromImage(bmp_Buffer);
                    Font sFont = new Font("Consolas", 8f);
                    Size seatSize = new Size(32, 20);
                    int x = 0; int y = 0; int z = 0;
                    foreach (Seat s in seats)
                    {
                        G.FillRectangle(seatBrushes[s.State], 
                                        new Rectangle( s.Location, seatSize) );
                        G.DrawString(s.Name, sFont, Brushes.Black, s.Location);
                    }
                    G.Dispose();
                    sFont.Dispose();
                    try { bmp_Display = (Bitmap)bmp_Buffer.Clone(); } 
                    catch { /*!!just for testing!!*/ }
                    //lock(bmp_Display) { bmp = (Bitmap) bmp_Buffer.Clone(); }
                }
            }
        }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if ((e.Cancelled == true))
        { this.tbProgress.Text += "Cancelled!"; }
        else if (!(e.Error == null))
        { this.tbProgress.Text += ("Error: " + e.Error.Message); }
        else
        { panel1.Invalidate(); }
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        try { e.Graphics.DrawImage(bmp, Point.Empty); } catch {/*!!just for testing!!*/ }
        //lock (bmp){   e.Graphics.DrawImage(bmp, Point.Empty);    }
    }
