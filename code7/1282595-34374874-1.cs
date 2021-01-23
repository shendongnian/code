    class Test
    {
        Timer timer = new Timer();
        public void DoIt()
        {
            List<int> l = new List<int>() { 1, 2, 3, 4, 5, 6 };
            XElement xdoc = XElement.Load("../../XMLFile1.xml");
            xdoc.Element("num").Value = "0";
            xdoc.Element("max").Value = l.Count.ToString();
            xdoc.Save("../../XMLFile1.xml");
            timer.Interval = 5000;
            timer.Tick += printnum;
            timer.Enabled = true;
        }
        public void printnum(object sender, EventArgs ev)
        {
            try
            {
                XElement xdoc = XElement.Load("../../XMLFile1.xml");
                int num = int.Parse(xdoc.Element("num").Value);
                int max = int.Parse(xdoc.Element("max").Value);
                num += 1;
                Console.WriteLine(num);
                if (num < max)
                {
                    xdoc.Element("num").Value = num.ToString();
                    xdoc.Save("../../XMLFile1.xml");
                }
                else
                {
                    Console.WriteLine("Finish");
                    timer.Enabled = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
