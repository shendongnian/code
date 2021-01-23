    public class ConcretePage : BasePage 
    {
        protected override GridView GetGridView()
        {
            //return GridView of this page 
            return GridView1;
        }
        //Optional, may needed on some pages
        public override void DisplayRecords()
        {
            base.DisplayRecords();
            //page specific logic here
        }
    }
