    public class YourHub : Hub
    {
        public void GetLearnerTreasureItem(int id)
        {
            List<The_Factory_Chante.Models.Learner_Treasure> lern;
            using (The_Factory_Chante.Models.The_FactoryDBContext db2 = new The_Factory_Chante.Models.The_FactoryDBContext())
            {
             string imageSource = "";
             lern = db2.Learner_Treasure.ToList();
             if (lern != null)
             {
               foreach (var item in lern)
               {
                 if (item.learnerID == UserInfo.ID)
                 {
                   byte[] bytes = db2.Treasures.FirstOrDefault(au => au.treasureID == item.treasureID).itemImage;
                  string imageBase = Convert.ToBase64String(bytes);
                  imageSource = string.Format("data:image/gif;base64,{0}", imageBase);
                  <img id="@item.treasureID" src="@imageSource"/>
                }
            }
            // This will now call the getImage function on your view.
            Clients.All.getImage(imageSource);
        }
    }
