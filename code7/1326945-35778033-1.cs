    public partial class Form1 : Form
    {
        private int page = 1;
        private int pageCount = 0;
        List<Button> MDButList = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            GenerateButtons(60);
            SetButtons(page);
        }
        private void GenerateButtons(decimal number)
        {
            for (int i = 0; i < number; i++)
            {
                Button a = new Button();
                a.Text = "But" + i;
                MDButList.Add(a);
            }
            pageCount = Convert.ToInt32(Math.Ceiling(number / 14));
        }
        private void SetButtons(int page)
        {
            labPageNum.Text = page.ToString() + " / " + pageCount.ToString();
            int ButPosX = 2; 
            int ButPosY = 2; 
            for (int i = panMDItems.Controls.Count - 1; i >= 0; --i)
                panMDItems.Controls[i].Dispose();
            int upperlimit=(page * 14) - 1;
            if (upperlimit>MDButList.Count-1) upperlimit=MDButList.Count-1;
            for (int i = (page-1) * 14; i <=upperlimit ; i++)
            {
                Button NewPOBut = MDButList[i]; 
               
                SetPOButPos(ref ButPosX, ref ButPosY, ref NewPOBut);
                if (i % 2 != 0)
                {
                    ButPosX = 2;
                    ButPosY += NewPOBut.Height + 10;
                }
                else
                {
                    ButPosX += NewPOBut.Width + 10;
                }
            }
        }
        private void SetPOButPos(ref int ButPosX, ref int ButPosY, ref Button NewPOBut)
        {
            NewPOBut.Location = new Point(ButPosX, ButPosY);
            panMDItems.Controls.Add(NewPOBut);
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (page > 1) page--;
            SetButtons(page);
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (page < pageCount) page++;
            SetButtons(page);
        }
    }
